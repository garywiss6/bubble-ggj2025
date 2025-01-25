using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientContainer : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _name;
    private IngredientData _data;

    public void Populate(IngredientData data)
    {
        _data = data;
        _icon.sprite = data.Sprite;
        _name.text = data.Name;
    }

    public void OnClick()
    {
        BubbleTeaManager.Instance.AddIngredient(_data);
    }
}
