using System;
using TMPro;
using UnityEngine;

public class BubbleTeaManager : SingletonBehaviour<BubbleTeaManager>
{
    [SerializeField] private BubbleTeaConfig _config;
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
            _bubbleTea.AddIngredient(ingredient);
            onAddIngredient?.Invoke(ingredient);
        }
    }

    public void CreateNewBubbleTea(CupSize size)
    {
        _bubbleTea = new BubbleTea(_config,size);
    }
}
