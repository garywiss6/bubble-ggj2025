using System.Collections.Generic;
using UnityEngine;

public class BubbleTea
{
    public BubbleTea(BubbleTeaConfig config, CupSize size)
    {
        _config = config;
        _size = size;
        _ingredients = new Dictionary<IngredientType, int>();
    }

    private BubbleTeaConfig _config;
    private CupSize _size;

    private Dictionary<IngredientType, int> _ingredients;

    private int _acidity;
    private int _sugar;
    private int _fruit;
    private bool _straw;

    public BubbleTeaConfig Config => _config;
    public CupSize Size => _size;
    public int Acidity => _acidity;
    public int Sugar => _sugar;
    public int Fruit => _fruit;
    public bool Straw => _straw;

    public bool TryAddIngredient(IngredientData ingredient)
    {
        if (!_config.GetMaxQuantity(_size).ContainsKey(ingredient.Type))
            return false;
        if (!_ingredients.ContainsKey(ingredient.Type) && _config.GetMaxQuantity(_size)[ingredient.Type] > 0)
        {
            AddIngredient(ingredient);
            return true;
        }
        if (_ingredients[ingredient.Type] + 1 <= _config.GetMaxQuantity(_size)[ingredient.Type])
        {
            AddIngredient(ingredient);
            return true;
        }
        return false;
    }
    public void AddIngredient(IngredientData ingredient)
    {
        if (!_ingredients.ContainsKey(ingredient.Type))
            _ingredients.Add(ingredient.Type, 0);
        _ingredients[ingredient.Type] += 1;
        _acidity += ingredient.Acidity;
        _acidity = Mathf.Clamp(_acidity, 0, _config.Acidity);
        _sugar += ingredient.Sugar;
        _sugar = Mathf.Clamp(_sugar, 0, _config.Sugar);
        _fruit += ingredient.Fruit;
        _fruit = Mathf.Clamp(_fruit, 0, _config.Fruit);
    }

    public void AddStraw()
    {
        _straw = true;
    }
    public override string ToString()
    {
        string str = $"acidity : {_acidity.ToString()}";
        str += $"\nsugar : {_sugar.ToString()}";
        str += $"\nfruit : {_fruit.ToString()}";
        return str;
    }
}
