using UnityEngine;

public class BubbleTeaTooltip : MonoBehaviour
{
    [SerializeField] private UIPanel _panel;
    [SerializeField] private BubbleTeaBar _acidityBar;
    [SerializeField] private BubbleTeaBar _fruitBar;
    [SerializeField] private BubbleTeaBar _sugarBar;
    public void Refresh(BubbleTea bubbleTea)
    {
        _acidityBar.Refresh(bubbleTea.Acidity);
        _fruitBar.Refresh(bubbleTea.Fruit);
        _sugarBar.Refresh(bubbleTea.Sugar);
    }
    public void Show() => _panel.Show();
    public void Hide() => _panel.Hide();
}
