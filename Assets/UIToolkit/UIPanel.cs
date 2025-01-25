using UnityEngine;

public class UIPanel : UIView
{
    [SerializeField] private UIState _showUiState;
    [SerializeField] private UIState _hideUiState;
    [SerializeField] private bool _hideOnStart;

    private void Start()
    {
        if (_hideOnStart)
            Hide();
    }

    public void Show()
    {
        if (_showUiState != null)
            _showUiState.DoBehaviour(this);
    }
    public void Hide()
    {
        if (_hideUiState != null)
        _hideUiState.DoBehaviour(this);
    }
}
