using System.Collections.Generic;
using UnityEngine;

public class MapControlState : MonoBehaviour, ControlObserver
{
    [SerializeField]
    private Cursor cursor;

    private ArrowKeyHandler arrowKeyHandler;
    private MapActionState currentSelectionState;
    private List<MapActionStateObserver> selectionStateObservers;

    void Awake()
    {
        GetComponent<InputManager>().ControlState = this;
        currentSelectionState = MapActionState.NoSelection;
        selectionStateObservers = new List<MapActionStateObserver>();
        arrowKeyHandler = new ArrowKeyHandler(cursor);
    }

    public void Notify(Dictionary<KeyCode, KeyState> inputs)
    {
        arrowKeyHandler.HandleArrowKeys(inputs);
        if (inputs[KeyCode.Return] == KeyState.Held)
            SetActionState(MapActionState.NoSelection);
    }

    public void RegisterActionStateObserver(MapActionStateObserver subscriber)
    {
        selectionStateObservers.Add(subscriber);
    }

    private void SetActionState(MapActionState actionState)
    {
        currentSelectionState = actionState;
        foreach (MapActionStateObserver observer in selectionStateObservers)
            observer.ChangeSelectionState(currentSelectionState);
    }
}
   