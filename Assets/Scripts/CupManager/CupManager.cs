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
    
    public void OnCupSelected(CupSize size)
    {
        _callback?.Invoke(size);
        _panel.Hide();
    }
}
