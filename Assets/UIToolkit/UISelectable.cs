using UnityEngine;

public class UISelectable : UIView
{
    [SerializeField] private UIState _normalState;
    [SerializeField] private UIState _highlightState;
    [SerializeField] private UIState _pressState;
    [SerializeField] private UIState _selectState;
    [SerializeField] private UIState _disableState;

    public void SetSelectable(SelectionStateType state)
    {
        Debug.Log($"Set {state}");
        if (!IsInit)
            return;
        switch (state)
        {
            case SelectionStateType.Normal:
                if (_normalState != null)
                    _normalState.DoBehaviour(this);
                break;
            case SelectionStateType.Highlighted:
                if (_highlightState != null)
                    _highlightState.DoBehaviour(this);
                break;
            case SelectionStateType.Pressed:
                if (_pressState != null)
                    _pressState.DoBehaviour(this);
                break;
            case SelectionStateType.Selected:
                if (_selectState != null)
                    _selectState.DoBehaviour(this);
                break;
            case SelectionStateType.Disabled:
                if (_disableState != null)
                    _disableState.DoBehaviour(this);
                break;
        }
    }
}
