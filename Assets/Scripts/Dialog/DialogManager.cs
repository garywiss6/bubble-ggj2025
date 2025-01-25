using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour, IPointerClickHandler
{
    
    [SerializeField] private DialogData _dialogDataTest;
    [SerializeField] private Image _finishCursor;
    DialogData _currentDialog;

    private DialogBubble _dialogBubble;

    private int _currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _dialogBubble = GetComponentInChildren<DialogBubble>();
        _dialogBubble.OnDialogFinished += OnDialogFinished;
        if (_dialogDataTest != null)
        {
            LaunchDialog(_dialogDataTest);            
        }
    }

    public void LaunchDialog(DialogData dialogData)
    {
        _finishCursor.color = Color.clear;
        _currentDialog = dialogData;
        _currentIndex = 0;

        _dialogBubble.ShowText(_currentDialog.Dialogs[_currentIndex]);
    }

    void OnDialogFinished()
    {
        _finishCursor.color = Color.blue;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_currentDialog != null)
        {
            if (_dialogBubble.IsTweening)
            {
                return;
            }
            _finishCursor.color = Color.clear;
            _currentIndex++;
            if (_currentIndex < _currentDialog.Dialogs.Count)
            {
                _dialogBubble.ShowText(_currentDialog.Dialogs[_currentIndex]);
            }
        }
    }
}
