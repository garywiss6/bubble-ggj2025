using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData",menuName ="Data/Ingredient")]
public class IngredientData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _ingredientIcon;
    [SerializeField] private Color _liquidColor;
    [SerializeField] private string _name;
    [SerializeField, Range(0, 5)] private int _acidity;
    [SerializeField, Range(0, 5)] private int _sugar;
    [SerializeField, Range(0, 5)] private int _fruit;
    
    public Sprite Sprite => _sprite;
    public Sprite IngredientIcon => _ingredientIcon;

    public Color LiquidColor => _liquidColor;
    public string Name => _name;

    public int Acidity => _acidity;
    public int Sugar => _sugar;
    public int Fruit => _fruit;
}
