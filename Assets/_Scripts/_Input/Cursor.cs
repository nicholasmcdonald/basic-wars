using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Map map;

    private int cursorRow = 0;
    private int cursorColumn = 0;

    private void Start()
    {
        cursorRow = (int)System.Math.Floor(map.rows / 2.0);
        cursorColumn = (int)System.Math.Floor(map.columns / 2.0);
        PositionCursor();
    }

    public void Move(int verticalMovement, int horizontalMovement)
    {
        cursorRow += verticalMovement;
        if (cursorRow < 0)
            cursorRow = 0;
        if (cursorRow >= map.rows)
            cursorRow = map.rows - 1;

        cursorColumn += horizontalMovement;
        if (cursorColumn < 0)
            cursorColumn = 0;
        if (cursorColumn >= map.columns)
            cursorColumn = map.columns - 1;

        PositionCursor();
    }

    void PositionCursor()
    {
        transform.localPosition = new Vector2(cursorColumn + 0.5f, cursorRow + 0.5f);
    }
}
