using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class DialogBubble : SerializedMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _DialogText;
    private Tween _currentTween;
    private DelegateDefinition.void_D_void _onDialogFinished;

    [SerializeField] private Image _bubble;
    [SerializeField]
    private Dictionary<DialogText.SpeakerType, Sprite> _bubbleSprites;

    [SerializeField]
    private CanvasGroup _group;

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
            ClientAnimator.Instance.SetState(0);
        }
    }

    public void ShowText(string text, DialogText.SpeakerType speakerType)
    {
        if (speakerType == DialogText.SpeakerType.Customer)
        {
            ClientAnimator.Instance.SetState(1);
        }
        else
        {
            ClientAnimator.Instance.SetState(0);
        }

        _group.alpha = 1;
        if (_currentTween != null)
            _currentTween.Kill();
        _DialogText.text = "";
        _bubble.sprite = _bubbleSprites[speakerType];
        _currentTween = _DialogText.DOText(text, 10.0f)
            .SetSpeedBased(true)
            .OnComplete(() =>
            {
                _onDialogFinished?.Invoke(); _currentTween = null;
                ClientAnimator.Instance.SetState(0);
            });
    }
}
