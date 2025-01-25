using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData",menuName ="Data/Ingredient")]
public class IngredientData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private IngredientType _type;
    [SerializeField, Range(-5, 5)] private float _acidity;
    [SerializeField, Range(-5, 5)] private float _sugar;
    [SerializeField, Range(-5, 5)] private float _fruit;
    
    public Sprite Sprite => _sprite;
    public string Name => _name;

    public IngredientType Type => _type;
    public float Acidity => _acidity;
    public float Sugar => _sugar;
    public float Fruit => _fruit;
}
