using UnityEngine;

public class StateCupSelection : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        CupManager.Instance.Populate(OnSelectCup);
    }

    public override void OnExit()
    {
        base.OnExit();
        CupManager.Instance.Hide();
    }

    private void OnSelectCup(CupSize size)
    {
        BubbleTeaManager.Instance.CreateNewBubbleTea(size);
        StateManager.Instance.ChangeState(new StateBubbleSelection());
    }
}
