using UnityEngine;

public class StateManager : SingletonBehaviour<StateManager>
{
    private AState _currentState;

    public void ChangeState(AState state)
    {
        if (_currentState != null)
            _currentState.OnExit();
        _currentState = state;
        _currentState.OnEnter();
    }
}
