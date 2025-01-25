using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class UIView : MonoBehaviour
{
    private bool _isShow;
    [SerializeField] private RectTransform _rt;
    [SerializeField] private CanvasGroup _cg;

    private Vector2 _originePosition;
    private float _origineScale;
    private float _origineRotation;
    private float _origineAlpha;

    public RectTransform Rt => _rt;
    public CanvasGroup Cg => _cg;

    public Vector2 OriginePosition => _originePosition;
    public float OriginalineScale => _origineScale;
    public float OrigineRotation => _origineRotation;
    public float OrigineAlpha => _origineAlpha;

    void Awake()
    {
        _origineAlpha = _cg.alpha;
        _originePosition = _rt.anchoredPosition;
        _origineScale = _rt.localScale.x;
        _origineRotation = _rt.rotation.z;
    }
}

