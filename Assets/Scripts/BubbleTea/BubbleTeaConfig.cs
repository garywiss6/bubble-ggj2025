using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BubbleTeaConfig",menuName ="Data/BubbleTeaConfig")]
public class BubbleTeaConfig : SerializedScriptableObject
{
    [SerializeField] private int _acidity;
    [SerializeField] private int _sugar;
    [SerializeField] private int _fruit;
    [SerializeField] private int _cupScore;
    [SerializeField] private int _strawScore;

    [SerializeField] private Dictionary<IngredientType, int> _maxQuantityMedium;
    [SerializeField] private Dictionary<IngredientType, int> _maxQuantityLarge;

    public int Acidity => _acidity;
    public int Sugar => _sugar;
    public int Fruit => _fruit;
    public int CupScore => _cupScore;
    public int StrawScore => _strawScore;

    public Dictionary<IngredientType, int> GetMaxQuantity(CupSize size)
    {
        if (size == CupSize.Medium)
            return _maxQuantityMedium;
        else
            return _maxQuantityLarge;

    }
}
