using UnityEngine;

public class StateClientArrival : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Anim arrivé client
        //Dialogue
        ClientManager.Instance.OnClientFinishWelcome += OnClientFinished;
        ClientManager.Instance.EnterClient();

    }

    void OnClientFinished()
    {
        ClientManager.Instance.OnClientFinishWelcome -= OnClientFinished;
        StateManager.Instance.ChangeState(new StateCupSelection());
    }

    public override void OnExit()
    {
        base.OnExit();
        RequestManager.Instance.AddRequest(ClientManager.Instance.CurrentClient.RequestData);
    }
}
