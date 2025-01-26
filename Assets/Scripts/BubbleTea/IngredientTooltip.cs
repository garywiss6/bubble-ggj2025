using UnityEngine;
using System.Collections.Generic;

public class IngredientTooltip : MonoBehaviour
{
    [SerializeField] private List<GameObject> _dots;
    public void Populate(int value)
    {
        foreach (GameObject dot in _dots)
            dot.SetActive(false);

        for (int i = 0; i <= value; i++)
        {
            if (i >= _dots.Count)
                return;
            _dots[i].SetActive(true);
        }
    }
}
