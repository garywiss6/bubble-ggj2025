using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BubbleTeaConfig",menuName ="Data/BubbleTeaConfig")]
public class BubbleTeaConfig : SerializedScriptableObject
{
    [SerializeField] private float _acidity;
    [SerializeField] private float _sugar;
    [SerializeField] private float _fruit;

    [SerializeField] private Dictionary<IngredientType, int> _maxQuantityMedium;
    [SerializeField] private Dictionary<IngredientType, int> _maxQuantityLarge;

    public float Acidity => _acidity;
    public float Sugar => _sugar;
    public float Fruit => _fruit;

    public Dictionary<IngredientType, int> GetMaxQuantity(CupSize size)
    {
        if (size == CupSize.Medium)
            return _maxQuantityMedium;
        else
            return _maxQuantityLarge;

    }
}
