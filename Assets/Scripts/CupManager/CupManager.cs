using System;
using UnityEngine;

public class CupManager : SingletonBehaviour<CupManager>
{
    [SerializeField] private UIPanel _panel;
    private Action<CupSize> _callback;
    public void Populate(Action<CupSize> callback)
    {
        _callback = callback;
        _panel.Show();
    }

    public void OnCupSelected(int size)
    {
        _callback?.Invoke((CupSize)size);
        _panel.Hide();
    }

    public void Hide()
    {
        _panel.Hide();
    }
}
