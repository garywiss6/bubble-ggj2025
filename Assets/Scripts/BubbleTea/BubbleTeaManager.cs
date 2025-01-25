using System;
using TMPro;
using UnityEngine;

public class BubbleTeaManager : SingletonBehaviour<BubbleTeaManager>
{
    [SerializeField] private BubbleTeaConfig _config;
    [SerializeField] private TextMeshProUGUI _debugText;
    public event DelegateDefinition.void_D_Ingredient onAddIngredient;
    private BubbleTea _bubbleTea;
    public BubbleTea BubbleTea => _bubbleTea;
    public void PopulateBubble()
    {
    }

    public void AddIngredient(IngredientData ingredient)
    {
        if (_bubbleTea != null)
        {
            if (_bubbleTea.TryAddIngredient(ingredient))
                onAddIngredient?.Invoke(ingredient);
            _debugText.text = _bubbleTea.ToString();
        }
    }

    public void CreateNewBubbleTea(CupSize size)
    {
        _bubbleTea = new BubbleTea(_config,size);
    }
}
