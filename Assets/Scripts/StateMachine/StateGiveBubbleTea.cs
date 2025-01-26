using UnityEngine;

public class StateGiveBubbleTea : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Play fill anim on customer
        BubbleTea bubbleTea = BubbleTeaManager.Instance.BubbleTea;
        bool answerRequest = RequestManager.Instance.SendBubbleTea(bubbleTea);
        ClientManager.Instance.OnClientFinishWelcome += FinishDialog;
        ClientAnimator.Instance._trigger += ClientLeaveEnd;
        if (!answerRequest)
            ClientManager.Instance.ClientLoseDialog();
        else
            ClientManager.Instance.ClientWinDialog();
        BubbleTeaManager.Instance.HideTooltip();
    }

    private void FinishDialog()
    {
        ClientManager.Instance.OnClientFinishWelcome -= FinishDialog;
        DialogManager.Instance.Hide();
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
