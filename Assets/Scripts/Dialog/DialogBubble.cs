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

    [SerializeField] private List<AudioClip> _voices;

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
        int nbChara = 0;
        _currentTween = _DialogText.DOText(text, 12.0f)
            .SetSpeedBased(true)
            .SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                if (_DialogText.text.Length > nbChara)
                {
                    nbChara = _DialogText.text.Length;
                    if (_DialogText.text[nbChara - 1] >= 'a' && _DialogText.text[nbChara - 1] <= 'z')
                    {
                        SoundController.Instance.PlaySound2D(_voices[Random.Range(0, _voices.Count)], gameObject, 1.0f, true, speakerType == DialogText.SpeakerType.Customer ? 2.0f : 1.0f);
                    }
                }
            })
            .OnComplete(() =>
            {
                _onDialogFinished?.Invoke(); _currentTween = null;
                ClientAnimator.Instance.SetState(0);
            });
    }
}
