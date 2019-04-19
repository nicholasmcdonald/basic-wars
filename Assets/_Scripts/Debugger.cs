using UnityEngine;

public class Debugger : MonoBehaviour
{
    public GameObject infantry;
    public GameObject battleship;
    public GameObject helicopter;

    public void Spawn(GameObject prefab)
    {
        Unit.Spawn(prefab, GameObject.FindGameObjectWithTag("Player").GetComponent<Cursor>().Position);
    }
}
