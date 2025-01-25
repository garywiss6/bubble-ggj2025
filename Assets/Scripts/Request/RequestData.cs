using UnityEngine;

public class RequestData : ScriptableObject
{
    [SerializeField] private float _exigence;

    [SerializeField,Range(0,5)] private float _acidity;
    [SerializeField,Range(0,5)] private float _softness;
    [SerializeField,Range(0,5)] private float _sugar;
    [SerializeField,Range(0,5)] private float _fruit;
}
