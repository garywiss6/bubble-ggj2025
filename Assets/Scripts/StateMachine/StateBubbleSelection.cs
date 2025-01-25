using UnityEngine;

public class StateBubbleSelection : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Show Bubble MiniGame Here
        BubbleTeaManager.Instance.onAddIngredient += OnAddIngredient;
    }

    public override void OnExit()
    {
        base.OnExit();
        //Hide Bubble MiniGame Here
        BubbleTeaManager.Instance.onAddIngredient -= OnAddIngredient;
    }

    private void OnAddIngredient(IngredientData ingredient)
    {
        StateManager.Instance.ChangeState(new StateLiquidSelection());
    }
}
