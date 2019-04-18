using UnityEngine;

public class Cursor : MonoBehaviour, MapActionStateObserver
{
    private Map map;
    [SerializeField]
    private CameraController camera;
    private int cursorRow = 0;
    private int cursorColumn = 0;

    /**
     * The tile clicked when the last MapActionState change occurred
     */
    public MapTile SelectedTile { get; private set; }

    /**
    * The tile currently pointed at
    */
    public MapTile HoveredTile
    {
        get { return map.GetMapTileAt(cursorRow, cursorColumn); }
    }

    public Vector2Int Position
    {
        get { return new Vector2Int(cursorColumn, cursorRow); }
    }

    void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        cursorRow = (int)System.Math.Floor(map.Rows / 2.0);
        cursorColumn = (int)System.Math.Floor(map.Columns / 2.0);
        PositionCursor();
    }

    public void ChangeSelectionState(MapActionState newActionState)
    {
        if (newActionState == MapActionState.NoSelection)
        {
            SelectedTile = null;
        }
        else if (newActionState == MapActionState.Movement)
        {
            SelectedTile = HoveredTile;
            // Change graphic
        }
        else if (newActionState == MapActionState.Attack)
        {
            // etc...
        }
    }

    /**
     * Move the cursor to a neighbouring tile.
     **/
    public void Move(Vector2Int motion)
    {
        Vector2Int safeTarget = GetSafeTarget(motion);
        PositionCursor(safeTarget);
        camera.MoveToKeepCursorInFocus(safeTarget, motion);
    }

    Vector2Int GetSafeTarget(Vector2Int motion)
    {
        Vector2Int safeTarget = new Vector2Int(cursorColumn, cursorRow) + motion;

        if (safeTarget.y <= 0)
            safeTarget.y = 0;
        else if (safeTarget.y >= map.Rows)
            safeTarget.y = map.Rows - 1;

        if (safeTarget.x <= 0)
            safeTarget.x = 0;
        else if (safeTarget.x >= map.Columns)
            safeTarget.x = map.Columns - 1;

        return safeTarget;
    }

    void PositionCursor()
    {
        transform.localPosition = new Vector2(cursorColumn + 0.5f, cursorRow + 0.5f);
    }

    void PositionCursor(Vector2Int target)
    {
        cursorRow = target.y;
        cursorColumn = target.x;
        transform.localPosition = new Vector2(cursorColumn + 0.5f, cursorRow + 0.5f);
    }
}
