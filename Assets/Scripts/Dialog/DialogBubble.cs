using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class DialogBubble : SerializedMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bartenderText;
    [SerializeField] private TextMeshProUGUI _customerText;
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
        set
        {
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
            ClientAnimator.Instance.SetTalk(false);
        }
    }

    public void ShowText(string text, DialogText.SpeakerType speakerType)
    {
        TextMeshProUGUI uiText;
        if (speakerType == DialogText.SpeakerType.Customer)
        {
            ClientAnimator.Instance.SetTalk(true);
            uiText = _customerText;
        }
        else
        {
            ClientAnimator.Instance.SetTalk(false);
            uiText = _bartenderText;
        }

        _group.alpha = 1;
        if (_currentTween != null)
            _currentTween.Kill();
        _bartenderText.text = "";
        _customerText.text = "";
        _bubble.sprite = _bubbleSprites[speakerType];
        int nbChara = 0;
        _currentTween = uiText.DOText(text, 12.0f)
            .SetSpeedBased(true)
            .SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                if (uiText.text.Length > nbChara)
                {
                    nbChara = uiText.text.Length;
                    if (uiText.text[nbChara - 1] >= 'a' && uiText.text[nbChara - 1] <= 'z')
                    {
                        SoundController.Instance.PlaySound2D(_voices[Random.Range(0, _voices.Count)], gameObject, 1.0f, true, speakerType == DialogText.SpeakerType.Customer ? 2.0f : 1.0f);
                    }
                }
            })
            .OnComplete(() =>
            {
                _onDialogFinished?.Invoke(); _currentTween = null;
                ClientAnimator.Instance.SetTalk(false);
            });
    }
}
