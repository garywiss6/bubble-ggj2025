using UnityEngine;

public class StateStraw : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Show Straw MiniGame Here
    }

    public override void OnExit()
    {
        base.OnExit();
        //Hide Straw MiniGame Here
    }

    private void OnStrawPut()
    {
        StateManager.Instance.ChangeState(new StateGiveBubbleTea());
    }
}
