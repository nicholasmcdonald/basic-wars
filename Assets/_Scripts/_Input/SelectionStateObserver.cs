using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SelectionStateObserver
{
    void ChangeSelectionState(SelectionState newSelectionState);
}
