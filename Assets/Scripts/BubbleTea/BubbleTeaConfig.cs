using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BubbleTeaConfig",menuName ="Data/BubbleTeaConfig")]
public class BubbleTeaConfig : SerializedScriptableObject
{
    [SerializeField] private float _acidity;
    [SerializeField] private float _softness;
    [SerializeField] private float _sugar;
    [SerializeField] private float _fruit;

    [SerializeField] private Dictionary<IngredientType, int> _maxQuantity;

    public float Acidity => _acidity;
    public float Softness => _softness;
    public float Sugar => _sugar;
    public float Fruit => _fruit;
    public Dictionary<IngredientType, int> MaxQuantity => _maxQuantity;
}
