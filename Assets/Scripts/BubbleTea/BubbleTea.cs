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

    private float _acidity;
    private float _sugar;
    private float _fruit;

    public float Acidity => _acidity;
    public float Sugar => _sugar;
    public float Fruit => _fruit;

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
    public override string ToString()
    {
        string str = $"acidity : {_acidity.ToString()}";
        str += $"\nsugar : {_sugar.ToString()}";
        str += $"\nfruit : {_fruit.ToString()}";
        return str;
    }
}
