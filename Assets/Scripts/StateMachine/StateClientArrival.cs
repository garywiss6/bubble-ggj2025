using UnityEngine;

public class StateClientArrival : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Anim arriv� client
        //Dialogue
        StateManager.Instance.ChangeState(new StateCupSelection());
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
