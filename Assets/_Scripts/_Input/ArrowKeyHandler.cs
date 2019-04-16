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

    public void HandleArrowKeys(Dictionary<KeyCode, KeyState> inputs)
    {
        // On key release stop scroll and reset rate limiter
        if (AllArrowKeysReleased(inputs))
        {
            if (arrowKeyHeld)
                DeactivateScroll();
        }
        else
        {
            // Ignore key inputs received between rate intervals
            if (arrowKeyActivationTime <= Time.time)
            {
                MoveCursor(inputs);
                SetRateLimiter();
            }
        }
    }

    void DeactivateScroll()
    {
        arrowKeyHeld = false;
        arrowKeyActivationTime = 0.0f;
    }

    void MoveCursor(Dictionary<KeyCode, KeyState> inputs)
    {
        int verticalMovement = GetInputAxisValue(inputs[KeyCode.S], inputs[KeyCode.W]);
        int horizontalMovement = GetInputAxisValue(inputs[KeyCode.A], inputs[KeyCode.D]);
        cursor.Move(new Vector2Int(horizontalMovement, verticalMovement));
    }

    void SetRateLimiter()
    {
        // Change the rate limiter based on whether scrolling has already started
        float limit = arrowKeyHeld ? SCROLL_CONTINUE_TIME : SCROLL_START_TIME;
        arrowKeyActivationTime = Time.time + limit;
        arrowKeyHeld = true;
    }

    private bool AllArrowKeysReleased(Dictionary<KeyCode, KeyState> inputs)
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