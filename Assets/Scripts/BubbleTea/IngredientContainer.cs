using UnityEngine;

public class IngredientContainer : MonoBehaviour
{
    [SerializeField] private IngredientData _data;
    public void OnClick()
    {
        BubbleTeaManager.Instance.AddIngredient(_data);
    }
}
