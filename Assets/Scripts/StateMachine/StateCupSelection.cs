using UnityEngine;

public class StateCupSelection : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        CupManager.Instance.Populate(OnSelectCup);
    }

    private void OnSelectCup(CupSize size)
    {
        BubbleTeaManager.Instance.CreateNewBubbleTea(size);
        StateManager.Instance.ChangeState(new StateBubbleSelection());
    }
}
