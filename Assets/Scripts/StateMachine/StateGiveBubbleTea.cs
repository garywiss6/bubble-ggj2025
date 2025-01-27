using UnityEngine;

public class StateGiveBubbleTea : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Play fill anim on customer
        PhysicsCupManager.Instance.OnSip += OnBubbleTeaSipped;
        PhysicsCupManager.Instance.GiveBubbleTea();
        ClientAnimator.Instance.TakeASip();
    }

    public void OnBubbleTeaSipped()
    {
        BubbleTea bubbleTea = BubbleTeaManager.Instance.BubbleTea;
        bool answerRequest = RequestManager.Instance.SendBubbleTea(bubbleTea);
        ClientManager.Instance.OnClientFinishWelcome += FinishDialog;
        ClientAnimator.Instance._trigger += ClientLeaveEnd;
        if (!answerRequest)
        {
            ClientAnimator.Instance.SetState(1);
            ClientManager.Instance.ClientLoseDialog();
        }
        else
        {
            ClientAnimator.Instance.SetState(2);
            ClientManager.Instance.ClientWinDialog();
        }
        BubbleTeaManager.Instance.HideTooltip();
        PhysicsCupManager.Instance.OnSip -= OnBubbleTeaSipped;
    }

    private void FinishDialog()
    {
        ClientManager.Instance.OnClientFinishWelcome -= FinishDialog;
        PhysicsCupManager.Instance.ResetBubbleCup();
        DialogManager.Instance.Hide();
        ClientAnimator.Instance.Trigger();
    }

    private void ClientLeaveEnd()
    {
        ClientAnimator.Instance._trigger -= ClientLeaveEnd;
        ClientManager.Instance.ExitClient();
        StateManager.Instance.ChangeState(new StateClientArrival());
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
