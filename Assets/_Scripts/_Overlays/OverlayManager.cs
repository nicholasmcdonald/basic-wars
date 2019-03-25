using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    private Map map;

    void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        transform.position = new Vector2(0, 0);
        GenerateOverlay();
    }

    private void GenerateOverlay()
    {
        // Make an invisible grid over the map, filled with Overlay Tile prefabs
        // Potentially use class to hide algorithm
    }

    private void ChangeOverlay()
    {
        // Need to know MapActionState to figure out colours
        // Need navmap to figure out display area
    }
}
