using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const int VIEWPORT_WIDTH = 15;
    private const int VIEWPORT_HEIGHT = 10;

    [SerializeField]
    private Map map;

    private float viewportCentreX { get { return VIEWPORT_WIDTH / 2.0f; } }
    private float viewportCentreY { get { return VIEWPORT_HEIGHT / 2.0f; } }

    private Rect ViewPortBounds
    {
        get
        {
            Vector3 cameraCentre = Camera.main.transform.position;

            Vector2 bottomLeftCorner = new Vector2(cameraCentre.x - viewportCentreX, cameraCentre.y - viewportCentreY);
            Vector2 cameraSize = new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT);
            return new Rect(bottomLeftCorner, cameraSize);
        }
    }
  
    public void MoveToKeepCursorInFocus(Vector2Int destination, Vector2Int motion)
    {
        Vector2Int origin = destination - motion;
        int motionX = 0, motionY = 0;

        // The camera remains in place unless the cursor is moving into a boundary.
        // Consider both axes separately.
        if (CursorIsMovingIntoHorizontalBoundary(origin, destination))
            motionX = motion.x;
        if (CursorIsMovingIntoVerticalBoundary(origin, destination))
            motionY = motion.y;
        Vector2Int cameraMotion = new Vector2Int(motionX, motionY);
       
        // This accounts for the cursor moving diagonally into a corner when
        // the camera is already at the edge of one axis of the map.
        Vector2Int targetTile = GetTileRevealedByMotion(cameraMotion);
        if (targetTile.x < 0 || targetTile.x >= map.Columns)
            cameraMotion.x = 0;
        if (targetTile.y < 0 || targetTile.y >= map.Rows)
            cameraMotion.y = 0;

        bool cameraStaysWithinMapBounds = map.CheckBoundsFor(GetTileRevealedByMotion(cameraMotion));

        if (cameraStaysWithinMapBounds)
            transform.position += (Vector3Int)cameraMotion;
    }

    bool CursorIsMovingIntoVerticalBoundary(Vector2Int origin, Vector2Int destination)
    {
        // Needs to consider if the camera can move that way at all
        return InUpDownBoundary(destination.y) && !InUpDownBoundary(origin.y);
    }

    bool CursorIsMovingIntoHorizontalBoundary(Vector2Int origin, Vector2Int destination)
    {
        return InLeftRightBoundary(destination.x) && !InLeftRightBoundary(origin.x);
    }

    bool InLeftRightBoundary(int x)
    {
        return x < ViewPortBounds.xMin + 2 || x >= ViewPortBounds.xMax - 2;
    }

    bool InUpDownBoundary(int y)
    {
        return y < ViewPortBounds.yMin + 2 || y >= ViewPortBounds.yMax - 2;
    }

    Vector2Int GetTileRevealedByMotion(Vector2Int motion)
    {
        Vector2Int frustumCorner = new Vector2Int();

        // If motion is not occuring on an axis, the frustum side used is irrelevant
        if (motion.x < 0)
            frustumCorner.x = (int)ViewPortBounds.xMin;
        else
            frustumCorner.x = (int)ViewPortBounds.xMax - 1;

        if (motion.y < 0)
            frustumCorner.y = (int)ViewPortBounds.yMin;
        else
            frustumCorner.y = (int)ViewPortBounds.yMax - 1;

        return frustumCorner + motion;
    }
}
