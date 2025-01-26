using UnityEngine;

public class StateTeaSelection : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        IngredientBench.Instance.PopulateTea();
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
        PhysicsCupManager.Instance.FillTeaCup(ingredient);
        //StateManager.Instance.ChangeState(new StateLiquidSelection());
    }
}
