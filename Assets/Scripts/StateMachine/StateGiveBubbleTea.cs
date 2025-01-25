using UnityEngine;

public class StateGiveBubbleTea : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Play fill anim on customer
        BubbleTea bubbleTea = BubbleTeaManager.Instance.BubbleTea;
        bool answerRequest = RequestManager.Instance.SendBubbleTea(bubbleTea);
        StateManager.Instance.ChangeState(new StateClientArrival());
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
