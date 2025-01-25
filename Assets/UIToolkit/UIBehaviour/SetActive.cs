using UnityEngine;

public class SetActive : UIBehaviour
{
    [SerializeField] private bool _state;

    protected override void DoFromCurrent(UIView view)
    {
        view.gameObject.SetActive(_state);
    }

    protected override void DoFromStart(UIView view)
    {
        view.gameObject.SetActive(_state);
    }

    protected override void DoToCustom(UIView view)
    {
        view.gameObject.SetActive(_state);
    }
}
