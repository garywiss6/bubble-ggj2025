using UnityEngine;

public class StateCupSelection : AState
{
    public async override void OnEnter()
    {
        base.OnEnter();
        IngredientBench.Instance.PopulateCup();
        await Awaitable.WaitForSecondsAsync(.5f);
        CupManager.Instance.Populate(OnSelectCup);
    }

    public override void OnExit()
    {
        base.OnExit();
        IngredientBench.Instance.Hide();
        CupManager.Instance.Hide();
    }

    private void OnSelectCup(CupSize size)
    {
        BubbleTeaManager.Instance.CreateNewBubbleTea(size);
        StateManager.Instance.ChangeState(new StateBubbleSelection());
    }
}
