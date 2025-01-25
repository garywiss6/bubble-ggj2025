using UnityEngine;

public class StateClientArrival : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Anim arrivé client
        //Dialogue
        ClientManager.Instance.OnClientFinishWelcome += OnExit;
        ClientManager.Instance.EnterClient();

    }

    public override void OnExit()
    {
        ClientManager.Instance.OnClientFinishWelcome -= OnExit;
        StateManager.Instance.ChangeState(new StateCupSelection());
        base.OnExit();
    }
}
