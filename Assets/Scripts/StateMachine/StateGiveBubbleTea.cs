using UnityEngine;

public class StateGiveBubbleTea : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Play fill anim on customer
        BubbleTea bubbleTea = BubbleTeaManager.Instance.BubbleTea;
        bool answerRequest = RequestManager.Instance.SendBubbleTea(bubbleTea);
        BubbleTeaManager.Instance.HideTooltip();
        Debug.Log($"answerRequest : {answerRequest}");
        DialogManager.Instance.Hide();
        ClientAnimator.Instance._trigger += ClientLeaveEnd;
        ClientAnimator.Instance.Trigger();
    }

    private void ClientLeaveEnd()
    {
        ClientAnimator.Instance._trigger -= ClientLeaveEnd;
        StateManager.Instance.ChangeState(new StateClientArrival());

    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
