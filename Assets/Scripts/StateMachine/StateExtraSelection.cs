using UnityEngine;

public class StateExtraSelection : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        IngredientBench.Instance.PopulateExtra();
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
        StateManager.Instance.ChangeState(new StateStraw());
    }
}
