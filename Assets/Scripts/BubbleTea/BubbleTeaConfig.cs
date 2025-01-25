using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BubbleTeaConfig",menuName = "Data/Config/BubbleTea")]
public class BubbleTeaConfig : SerializedScriptableObject
{
    [SerializeField] private int _acidity;
    [SerializeField] private int _sugar;
    [SerializeField] private int _fruit;
    [SerializeField] private int _cupScore;
    [SerializeField] private int _strawScore;

    public int Acidity => _acidity;
    public int Sugar => _sugar;
    public int Fruit => _fruit;
    public int CupScore => _cupScore;
    public int StrawScore => _strawScore;
}
