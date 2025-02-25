using UnityEngine;

public class StateManager : SingletonBehaviour<StateManager>
{
    private AState _currentState;

    public void ChangeState(AState state)
    {
        if (_currentState != null)
            _currentState.OnExit();
        _currentState = state;
        Debug.Log($"ChangeState : {_currentState.ToString()}");
        _currentState.OnEnter();
    }

    public void Init()
    {
        ChangeState(new StateClientArrival());
    }
}
