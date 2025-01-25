using System.Collections.Generic;
using UnityEngine;

public class BubbleTea
{
    public BubbleTea(BubbleTeaConfig config)
    {
        _config = config;
        _ingredients = new Dictionary<IngredientType, int>();
    }

    private BubbleTeaConfig _config;

    private Dictionary<IngredientType, int> _ingredients;

    private float _acidity;
    private float _softness;
    private float _sugar;
    private float _fruit;

    public bool TryAddIngredient(IngredientData ingredient)
    {
        if (!_config.MaxQuantity.ContainsKey(ingredient.Type))
            return false;
        if (!_ingredients.ContainsKey(ingredient.Type) && _config.MaxQuantity[ingredient.Type] > 0)
        {
            AddIngredient(ingredient);
            return true;
        }
        if (_ingredients[ingredient.Type] + 1 <= _config.MaxQuantity[ingredient.Type])
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
        _softness += ingredient.Softness;
        _softness = Mathf.Clamp(_softness, 0, _config.Softness);
        _sugar += ingredient.Sugar;
        _sugar = Mathf.Clamp(_sugar, 0, _config.Sugar);
        _fruit += ingredient.Fruit;
        _fruit = Mathf.Clamp(_fruit, 0, _config.Fruit);
    }
    public override string ToString()
    {
        string str = $"acidity : {_acidity.ToString()}";
        str += $"\nsoftness : {_softness.ToString()}";
        str += $"\nsugar : {_sugar.ToString()}";
        str += $"\nfruit : {_fruit.ToString()}";
        return str;
    }
}
