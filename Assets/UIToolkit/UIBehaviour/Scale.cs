using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class Scale : UIBehaviour
{
    [SerializeField] private float scale;

    [SerializeField] private AnimationCurve _animCurve;
    [SerializeField] private float _animDuration = .2f;

    protected override void DoFromCurrent(UIView view)
    {
        float finalScale = view.Rt.localScale.magnitude + scale;
        view.Rt.DOScale(finalScale, _animDuration).SetEase(_animCurve);
    }

    protected override void DoFromCurrentInstant(UIView view)
    {
        float finalScale = view.Rt.localScale.magnitude + scale;
        view.Rt.localScale = Vector3.one * finalScale;
    }

    protected override void DoFromStart(UIView view)
    {
        float finalScale = view.OriginalineScale + scale;
        view.Rt.DOScale(finalScale, _animDuration).SetEase(_animCurve);
    }

    protected override void DoFromStartInstant(UIView view)
    {
        float finalScale = view.OriginalineScale + scale;
        view.Rt.localScale = Vector3.one * finalScale;
    }

    protected override void DoToCustom(UIView view)
    {
        view.Rt.DOScale(scale, _animDuration).SetEase(_animCurve);
    }

    protected override void DoToCustomInstant(UIView view)
    {
        view.Rt.localScale = Vector3.one * scale;
    }
}
