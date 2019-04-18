using UnityEngine;

public class Debugger : MonoBehaviour
{
    public GameObject infantry;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector2Int target = GameObject.FindGameObjectWithTag("Player").GetComponent<Cursor>().Position;
            Unit.Spawn(infantry, target);
            Debug.Log("Attempting to spawn infantry...");
        }
    }
}
