using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class CustomButton : Button
{
    [SerializeField] private UISelectable _view;
    [SerializeField] private RectTransform _rect;
    [SerializeField, SerializeReference] private List<UIElement> _UIElements = new List<UIElement>();

    public event Action onClickDelegate;

    protected override void Start()
    {
        base.Start();
        _rect = (RectTransform)transform;
    }

    public void Clear()
    {
        onClick = null;
        onClickDelegate = null;
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
        if (_view == null)
            return;
        SelectionStateType convertedState = (SelectionStateType)state;
        _view.SetSelectable(convertedState);
    }
}
