using UnityEngine;

public class StateBubbleSelection : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        IngredientBench.Instance.PopulateBubble();
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
        PhysicsCupManager.Instance.FillBobaCup(ingredient);
        //StateManager.Instance.ChangeState(new StateTeaSelection());
    }
}
