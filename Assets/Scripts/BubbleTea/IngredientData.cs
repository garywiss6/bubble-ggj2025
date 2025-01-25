using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData",menuName ="Data/Ingredient")]
public class IngredientData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private IngredientType _type;
    [SerializeField, Range(0, 5)] private int _acidity;
    [SerializeField, Range(0, 5)] private int _sugar;
    [SerializeField, Range(0, 5)] private int _fruit;
    
    public Sprite Sprite => _sprite;
    public string Name => _name;

    public IngredientType Type => _type;
    public int Acidity => _acidity;
    public int Sugar => _sugar;
    public int Fruit => _fruit;
}
