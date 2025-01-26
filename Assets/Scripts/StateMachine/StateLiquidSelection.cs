using UnityEngine;

public class StateLiquidSelection : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        IngredientBench.Instance.PopulateLiquid();
        BubbleTeaManager.Instance.onAddIngredient += OnAddIngredient;
    }

    public override void OnExit()
    {
        base.OnExit();
        IngredientBench.Instance.Hide();
        BubbleTeaManager.Instance.onAddIngredient -= OnAddIngredient;
    }

    private void OnAddIngredient(IngredientData ingredient)
    {
        PhysicsCupManager.Instance.FillLiquidClient(ingredient);
        //StateManager.Instance.ChangeState(new StateExtraSelection());
    }
}
