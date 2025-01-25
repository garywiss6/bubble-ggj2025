using System;
using UnityEngine;

[Serializable]
public abstract class UIBehaviour
{
    [SerializeField] protected RelativePositionStartType transistionType;
    public void DoBehaviour(UIView view)
    {
        switch (transistionType)
        {
            case RelativePositionStartType.FromStart:
                DoFromStart(view); 
                break;
            case RelativePositionStartType.FromCurrent:
                DoFromCurrent(view); 
                break;
            case RelativePositionStartType.ToCustom:
                DoToCustom(view); 
                break;
        }
    }
    protected abstract void DoFromStart(UIView view);
    protected abstract void DoFromCurrent(UIView view);
    protected abstract void DoToCustom(UIView view);
}
