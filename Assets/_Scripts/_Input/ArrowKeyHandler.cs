using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyHandler
{
    private Cursor cursor;

    private const float SCROLL_START_TIME = 0.2f;
    private const float SCROLL_CONTINUE_TIME = 0.05f;

    private float arrowKeyActivationTime;
    private bool arrowKeyHeld;

    public ArrowKeyHandler(Cursor cursor)
    {
        this.cursor = cursor;
    }

    public void DoStuff(Dictionary<KeyCode, KeyState> inputs)
    {
        if (!CheckAllArrowsReleased(inputs) || arrowKeyHeld)
            HandleArrows(inputs);
    }

    void HandleArrows(Dictionary<KeyCode, KeyState> inputs)
    {
        // On key release stop scroll and reset rate limiter
        if (CheckAllArrowsReleased(inputs))
        {
            arrowKeyHeld = false;
            arrowKeyActivationTime = 0.0f;
            return;
        }

        // Ignore key inputs received between rate intervals
        if (arrowKeyActivationTime > Time.time)
            return;

        int verticalMovement = GetInputAxisValue(inputs[KeyCode.S], inputs[KeyCode.W]);
        int horizontalMovement = GetInputAxisValue(inputs[KeyCode.A], inputs[KeyCode.D]);

        // Change the rate limiter based on whether scrolling has already started
        if (arrowKeyHeld)
        {
            arrowKeyActivationTime = Time.time + SCROLL_CONTINUE_TIME;
        }
        else
        {
            arrowKeyActivationTime = Time.time + SCROLL_START_TIME;
            arrowKeyHeld = true;
        }

        cursor.Move(new Vector2Int(horizontalMovement, verticalMovement));
    }

    private bool CheckAllArrowsReleased(Dictionary<KeyCode, KeyState> inputs)
    {
        var arrowKeys = new List<KeyCode> { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        foreach (KeyCode arrow in arrowKeys)
        {
            if (inputs[arrow] != KeyState.Released && inputs[arrow] != KeyState.None)
                return false;
        }

        return true;
    }

    private int GetInputAxisValue(KeyState negative, KeyState positive)
    {
        if (positive == KeyState.Pressed || positive == KeyState.Held)
            return 1;
        else if (negative == KeyState.Pressed || negative == KeyState.Held)
            return -1;
        else
            return 0;
    }
}