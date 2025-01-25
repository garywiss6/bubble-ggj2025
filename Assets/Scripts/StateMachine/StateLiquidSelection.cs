using UnityEngine;

public class StateLiquidSelection : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Show Liquid MiniGame Here
        BubbleTeaManager.Instance.onAddIngredient += OnAddIngredient;
    }

    public override void OnExit()
    {
        base.OnExit();
        //Hide Liquid MiniGame Here
        BubbleTeaManager.Instance.onAddIngredient -= OnAddIngredient;
    }

    private void OnAddIngredient(IngredientData ingredient)
    {
        StateManager.Instance.ChangeState(new StateExtraSelection());
    }
}
