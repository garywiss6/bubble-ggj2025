using UnityEngine;

public class StateExtraSelection : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Show Extra MiniGame Here
        BubbleTeaManager.Instance.onAddIngredient += OnAddIngredient;
    }

    public override void OnExit()
    {
        base.OnExit();
        //Hide Extra MiniGame Here
        BubbleTeaManager.Instance.onAddIngredient -= OnAddIngredient;
    }

    private void OnAddIngredient(IngredientData ingredient)
    {
        StateManager.Instance.ChangeState(new StateStraw());
    }
}
