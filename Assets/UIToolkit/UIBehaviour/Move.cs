using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class Move : UIBehaviour
{
    [SerializeField] private Vector2 _move;

    [SerializeField] private AnimationCurve _animCurve;
    [SerializeField] private float _animDuration = .2f;

    protected override void DoFromCurrent(UIView view)
    {
        Vector2 finalPos = view.Rt.anchoredPosition + _move;
        view.Rt.DOAnchorPos(finalPos, _animDuration).SetEase(_animCurve);
    }

    protected override void DoFromStart(UIView view)
    {
        Vector2 finalPos = view.OriginePosition + _move;
        view.Rt.DOAnchorPos(finalPos, _animDuration).SetEase(_animCurve);
    }

    protected override void DoToCustom(UIView view)
    {
        Vector2 finalPos = _move;
        view.Rt.DOAnchorPos(finalPos, _animDuration).SetEase(_animCurve);
    }
}

