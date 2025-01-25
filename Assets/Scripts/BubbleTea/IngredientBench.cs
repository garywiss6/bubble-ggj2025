using UnityEngine;
using System.Collections.Generic;

public class IngredientBench : SingletonBehaviour<IngredientBench>
{
    [SerializeField] private UIPanel _panel;
    [SerializeField] private IngredientContainer _prefab;
    [SerializeField] private Transform _container;

    public void Populate(List<IngredientData> _datas)
    {
        Clear();
        for (int i = 0; i < _datas.Count; i++)
        {
            IngredientData data = _datas[i];
            IngredientContainer container = Instantiate(_prefab, _container);
            container.Populate(data);
        }
        _panel.Show();
    }

    private void Clear()
    {
        foreach (Transform T in _container)
            Destroy(T.gameObject);
    }
}
