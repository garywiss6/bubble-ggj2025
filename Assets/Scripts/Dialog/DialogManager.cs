using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class DialogManager : MonoBehaviour, IPointerClickHandler
{
    static private DialogManager _instance;
    static public DialogManager Instance => _instance;
    [SerializeField] private DialogData _dialogDataTest;
    [SerializeField] private Image _finishCursor;
    DialogData _currentDialog;
    [SerializeField]
    private CanvasGroup _choices;
    [SerializeField]
    TextMeshProUGUI _firstChoice;
    [SerializeField]
    TextMeshProUGUI _secondChoice;

    private DialogBubble _dialogBubble;

    private int _currentIndex = 0;

    private DelegateDefinition.void_D_void _onDialogFinished;
    public DelegateDefinition.void_D_void OnDialogFinished
    {
        get
        {
            return _onDialogFinished;
        }
        set
        {
            _onDialogFinished = value;
        }
    }

    void Awake()
    {
        _instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _dialogBubble = GetComponentInChildren<DialogBubble>();
        _dialogBubble.OnDialogFinished += OnTextFinished;
        _choices.alpha = 0;
        _choices.interactable = false;
        
        if (_dialogDataTest != null)
        {
            LaunchDialog(_dialogDataTest);    
        }
    }

    public void OnFirstChoice()
    {
        LaunchDialog(_currentDialog.Dialogs[_currentIndex].choices[0].response);
    }
    
    public void OnSecondChoice()
    {
        LaunchDialog(_currentDialog.Dialogs[_currentIndex].choices[1].response);
    }

    public void LaunchDialog(DialogData dialogData)
    {
        _finishCursor.color = Color.clear;
        _currentDialog = dialogData;
        _currentIndex = 0;

        _dialogBubble.ShowText(_currentDialog.Dialogs[_currentIndex].message, _currentDialog.Dialogs[_currentIndex].speaker);
    }

    void OnTextFinished()
    {
        if (_currentDialog.Dialogs[_currentIndex].hasChoice)
        {
            _firstChoice.text = _currentDialog.Dialogs[_currentIndex].choices[0].message;
            _secondChoice.text = _currentDialog.Dialogs[_currentIndex].choices[1].message;
            _choices.DOFade(1, 0.8f).OnComplete(() => {_choices.interactable = true;});
        }
        else
        {
            _finishCursor.color = Color.blue;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_currentDialog != null && _currentIndex < _currentDialog.Dialogs.Count && !_currentDialog.Dialogs[_currentIndex].hasChoice)
        {
            if (_dialogBubble.IsTweening)
            {
                _dialogBubble.SkipTextTyping();
                return;
            }
            _choices.alpha = 0;
            _choices.interactable = false;
            _finishCursor.color = Color.clear;
            _currentIndex++;
            if (_currentIndex < _currentDialog.Dialogs.Count)
            {
                _dialogBubble.ShowText(_currentDialog.Dialogs[_currentIndex].message, _currentDialog.Dialogs[_currentIndex].speaker);
            }
            else
            {
                _onDialogFinished?.Invoke();
            }
        }
    }
}
