using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngredientContainer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private GameObject _tooltipContainer;
    [SerializeField] private IngredientTooltip _acidityTooltip;
    [SerializeField] private IngredientTooltip _fruitTooltip;
    [SerializeField] private IngredientTooltip _sugarTooltip;
    private IngredientData _data;

    public void Populate(IngredientData data)
    {
        _data = data;
        _icon.sprite = data.IngredientIcon;
        _name.text = data.Name;
        _acidityTooltip.Populate(data.Acidity);
        _fruitTooltip.Populate(data.Fruit);
        _sugarTooltip.Populate(data.Sugar);
    }

    public void OnClick()
    {
        BubbleTeaManager.Instance.AddIngredient(_data);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _tooltipContainer.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _tooltipContainer.SetActive(false);
    }
}
