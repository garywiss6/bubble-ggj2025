using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class IngredientBench : SingletonBehaviour<IngredientBench>
{
    [SerializeField] private BenchConfig _config;
    [SerializeField] private UIPanel _panel;
    [SerializeField] private IngredientContainer _prefab;
    [SerializeField] private Transform _container;

    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private string _cupText;
    [SerializeField] private string _bubbleText;
    [SerializeField] private string _teaText;
    [SerializeField] private string _milkText;
    [SerializeField] private string _extraText;

    public void PopulateCup()
    {
        Populate(new List<IngredientData>());
        _header.text = _cupText;
    }
    public void PopulateBubble()
    {
        Populate(_config.Bubble);
        _header.text = _bubbleText;
    }
    public void PopulateTea()
    {
        Populate(_config.Tea);
        _header.text = _teaText;
    }
    public void PopulateLiquid()
    {
        Populate(_config.Liquid);
        _header.text = _milkText;
    }
    public void PopulateExtra()
    {
        Populate(_config.Extra);
        _header.text = _extraText;
    }

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
