using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    [SerializeField]
    private Map map;

    void Start()
    {
        transform.position = new Vector2(0, 0);
        GenerateOverlay();
    }

    private void GenerateOverlay()
    {
        // Make an invisible grid over the map, filled with Overlay Tile prefabs
        // Potentially use class to hide algorithm
    }

    public void ChangeOverlay(NavMap navMap, MapActionState state)
    {
        // Need to know MapActionState to figure out colours
        // Need navmap to figure out display area
    }
}
