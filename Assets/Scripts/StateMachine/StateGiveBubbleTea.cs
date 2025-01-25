using UnityEngine;

public class StateGiveBubbleTea : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Play fill anim on customer
        BubbleTea bubbleTea = BubbleTeaManager.Instance.BubbleTea;
        bool answerRequest = RequestManager.Instance.SendBubbleTea(bubbleTea);
        Debug.Log($"answerRequest : {answerRequest}");
        StateManager.Instance.ChangeState(new StateClientArrival());
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
