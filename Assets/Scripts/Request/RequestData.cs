using UnityEngine;

[CreateAssetMenu(fileName = "RequestData", menuName = "Data/RequestData")]
public class RequestData : ScriptableObject
{
    [SerializeField, Range(0, 15)] private float _exigence;

    [SerializeField, Range(0, 5)] private float _acidity;
    [SerializeField, Range(0, 5)] private float _sugar;
    [SerializeField, Range(0, 5)] private float _fruit;

    public bool AnswerRequest(BubbleTea tea)
    {
        if (tea == null)
            return false;

        float unaccuracy = 0;
        unaccuracy += Mathf.Abs(_acidity - tea.Acidity);
        unaccuracy += Mathf.Abs(_sugar - tea.Sugar);
        unaccuracy += Mathf.Abs(_fruit - tea.Fruit);

        return unaccuracy <= _exigence;
    }
}
