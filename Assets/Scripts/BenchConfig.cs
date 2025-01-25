using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BenchConfig", menuName ="Data/Config/Bench")]
public class BenchConfig : ScriptableObject
{
    [SerializeField] private List<IngredientData> _bubble;
    [SerializeField] private List<IngredientData> _tea;
    [SerializeField] private List<IngredientData> _liquid;
    [SerializeField] private List<IngredientData> _extra;

    public List<IngredientData> Bubble => _bubble;
    public List<IngredientData> Tea => _tea;
    public List<IngredientData> Liquid => _liquid;
    public List<IngredientData> Extra => _extra;
}
