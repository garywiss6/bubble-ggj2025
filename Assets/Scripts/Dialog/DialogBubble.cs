using UnityEngine;
using TMPro;
using DG.Tweening;

public class DialogBubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _DialogText;
    private Tween _currentTween;
    private DelegateDefinition.void_D_void _onDialogFinished;

    public DelegateDefinition.void_D_void OnDialogFinished
    {
        get { return _onDialogFinished; }
        set { 
        _onDialogFinished = value;
        }
    }

    public bool IsTweening
    {
        get
        {
            return _currentTween != null && _currentTween.IsPlaying(); 
        }
    }

    public void SkipTextTyping()
    {
        if (_currentTween != null)
        {
            _currentTween.Complete();
            _currentTween = null;
        }
    }

    public void ShowText(string text)
    {
        if (_currentTween != null)
            _currentTween.Kill();
        _DialogText.text = "";
        _currentTween = _DialogText.DOText(text, 1.0f).OnComplete(() => { _onDialogFinished?.Invoke();_currentTween = null; });
    }
}
