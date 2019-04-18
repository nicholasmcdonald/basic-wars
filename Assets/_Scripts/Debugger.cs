using UnityEngine;

public class Debugger : MonoBehaviour
{
    public GameObject infantry;
    public GameObject battleship;
    public GameObject helicopter;

    private void Update()
    {
        Vector2Int target = GameObject.FindGameObjectWithTag("Player").GetComponent<Cursor>().Position;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Unit.Spawn(infantry, target);
            Debug.Log("Attempting to spawn infantry...");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Unit.Spawn(battleship, target);
            Debug.Log("Attempting to spawn battleship...");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Unit.Spawn(helicopter, target);
            Debug.Log("Attempting to spawn helicopter...");
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Map map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
            Debug.Log(map.GetMapTileAt(target).WorldPosition);
        }
    }
}
