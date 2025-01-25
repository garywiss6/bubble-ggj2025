using UnityEngine;
using System.Collections.Generic;

public class IngredientBench : SingletonBehaviour<IngredientBench>
{
    [SerializeField] private BenchConfig _config;
    [SerializeField] private UIPanel _panel;
    [SerializeField] private IngredientContainer _prefab;
    [SerializeField] private Transform _container;

    public void PopulateBubble() => Populate(_config.Bubble);
    public void PopulateTea() => Populate(_config.Tea);
    public void PopulateLiquid() => Populate(_config.Liquid);
    public void PopulateExtra() => Populate(_config.Extra);

    private void Populate(List<IngredientData> _datas)
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

    public void Hide()
    {
        _panel.Hide();
    }

    private void Clear()
    {
        foreach (Transform T in _container)
            Destroy(T.gameObject);
    }
}
