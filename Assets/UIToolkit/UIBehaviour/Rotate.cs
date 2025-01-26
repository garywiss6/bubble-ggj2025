using DG.Tweening;
using UnityEngine;

public class Rotate : UIBehaviour
{
    [SerializeField] private float _rotation;

    [SerializeField] private AnimationCurve _animCurve;
    [SerializeField] private float _animDuration = .2f;

    protected override void DoFromCurrent(UIView view)
    {
        Vector3 fRotation = new Vector3(view.Rt.rotation.x, view.Rt.rotation.y, view.Rt.rotation.z);
        fRotation.z += _rotation;
        view.Rt.DORotate(fRotation, _animDuration).SetEase(_animCurve);
    }

    protected override void DoFromCurrentInstant(UIView view)
    {
        Quaternion fRotation = view.Rt.rotation;
        fRotation.z += _rotation;
        view.Rt.rotation = fRotation;
    }

    protected override void DoFromStart(UIView view)
    {
        Vector3 fRotation = new Vector3(view.Rt.rotation.x, view.Rt.rotation.y, view.OrigineRotation);
        fRotation.z += _rotation;
        view.Rt.DORotate(fRotation, _animDuration).SetEase(_animCurve);
    }

    protected override void DoFromStartInstant(UIView view)
    {
        Quaternion fRotation = view.Rt.rotation;
        fRotation.z = view.OrigineRotation + _rotation;
        view.Rt.rotation = fRotation;
    }

    protected override void DoToCustom(UIView view)
    {
        Vector3 fRotation = new Vector3(view.Rt.rotation.x, view.Rt.rotation.y, _rotation);
        view.Rt.DORotate(fRotation, _animDuration).SetEase(_animCurve);
    }

    protected override void DoToCustomInstant(UIView view)
    {
        Quaternion fRotation = view.Rt.rotation;
        fRotation.z = _rotation;
        view.Rt.rotation = fRotation;
    }
}
