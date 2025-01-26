using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BubbleTeaBar : MonoBehaviour
{
    [SerializeField] private int _maxValue = 15;
    [SerializeField] private Image _fill;
    [SerializeField] private float _animSpeed;
    [SerializeField] private AnimationCurve _animCurve;

    public void Refresh(int value)
    {
        float ratio = (float)value / _maxValue;
        _fill.DOFillAmount(ratio, _animSpeed).SetEase(_animCurve);
    }
}
