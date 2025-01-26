using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

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
    private bool _isInit;

    public RectTransform Rt => _rt;
    public CanvasGroup Cg => _cg;

    public Vector2 OriginePosition => _originePosition;
    public float OriginalineScale => _origineScale;
    public float OrigineRotation => _origineRotation;
    public float OrigineAlpha => _origineAlpha;
    public bool IsInit => _isInit;
    void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        if (_cg == null)
            yield break;
        if (_rt == null)
            yield break;
        _origineAlpha = _cg.alpha;
        _originePosition = _rt.anchoredPosition;
        _origineScale = _rt.localScale.x;
        _origineRotation = _rt.rotation.z;
        _isInit = true;
    }
}

