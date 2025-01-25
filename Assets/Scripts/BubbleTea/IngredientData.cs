using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData",menuName ="Data/Ingredient")]
public class IngredientData : ScriptableObject
{
    [SerializeField] private IngredientType _type;
    [SerializeField, Range(-5, 5)] private float _acidity;
    [SerializeField, Range(-5, 5)] private float _softness;
    [SerializeField, Range(-5, 5)] private float _sugar;
    [SerializeField, Range(-5, 5)] private float _fruit;
    
    public IngredientType Type => _type;
    public float Acidity => _acidity;
    public float Softness => _softness;
    public float Sugar => _sugar;
    public float Fruit => _fruit;
}
