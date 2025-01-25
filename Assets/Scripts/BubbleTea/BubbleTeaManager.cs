using TMPro;
using UnityEngine;

public class BubbleTeaManager : SingletonBehaviour<BubbleTeaManager>
{
    [SerializeField] private BubbleTeaConfig _config;
    [SerializeField] private TextMeshProUGUI _debugText;
    public event DelegateDefinition.void_D_Ingredient onAddIngredient;
    private BubbleTea _bubbleTea;

    private void Awake()
    {
        CreateNewBubbleTea();
    }

    public void AddIngredient(IngredientData ingredient)
    {
        onAddIngredient?.Invoke(ingredient);
        if (_bubbleTea != null)
        {
            _bubbleTea.TryAddIngredient(ingredient);
            _debugText.text = _bubbleTea.ToString();
        }
    }

    public void CreateNewBubbleTea()
    {
        _bubbleTea = new BubbleTea(_config);
    }
}
