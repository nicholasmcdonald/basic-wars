using System.Collections.Generic;
using UnityEngine;

public class MapControlState : MonoBehaviour, ControlObserver
{
    [SerializeField]
    private Cursor cursor;

    private ArrowKeyHandler arrowKeyHandler;
    private MapActionState currentActionState;
    private List<MapActionStateObserver> selectionStateObservers;

    void Awake()
    {
        GetComponent<InputManager>().ControlState = this;
        currentActionState = MapActionState.NoSelection;
        selectionStateObservers = new List<MapActionStateObserver>();
        arrowKeyHandler = new ArrowKeyHandler(cursor);
    }

    public void Notify(Dictionary<KeyCode, KeyState> inputs)
    {
        if (ReturnKeyHandler(inputs))
            return;

        arrowKeyHandler.HandleArrowKeys(inputs);
    }

    public void RegisterActionStateObserver(MapActionStateObserver subscriber)
    {
        selectionStateObservers.Add(subscriber);
    }

    private void SetActionState(MapActionState actionState)
    {
        currentActionState = actionState;
        foreach (MapActionStateObserver observer in selectionStateObservers)
            observer.ChangeSelectionState(currentActionState);
    }

    private bool ReturnKeyHandler(Dictionary<KeyCode, KeyState> inputs)
    {
        if (currentActionState == MapActionState.NoSelection && inputs[KeyCode.Return] == KeyState.Pressed)
        {
            if (cursor.HoveredTile.Occupant != null)
            {
                SetActionState(MapActionState.Movement);
                return true;
            }
        }

        return false;
    }
}
   