using UnityEngine;

public class StateStraw : AState
{
    public override void OnEnter()
    {
        base.OnEnter();
        //Show Straw MiniGame Here (non)
        PhysicsCupManager.Instance.StrawInTheCup();
        BubbleTeaManager.Instance.BubbleTea.AddStraw();
        //OnStrawPut(); // Ligne de debug a remplacer par le mini jeu
    }

    public override void OnExit()
    {
        base.OnExit();
        //Hide Straw MiniGame Here
    }

    private void OnStrawPut()
    {
        //StateManager.Instance.ChangeState(new StateGiveBubbleTea());
    }
}
