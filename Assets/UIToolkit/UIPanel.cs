using UnityEngine;

public class UIPanel : UIView
{
    [SerializeField] private UIState _showUiState;
    [SerializeField] private UIState _hideUiState;
    public void Show() => _showUiState.DoBehaviour(this);
    public void Hide() => _hideUiState.DoBehaviour(this);
}
