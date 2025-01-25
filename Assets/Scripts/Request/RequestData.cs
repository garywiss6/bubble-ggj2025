using UnityEngine;

public class RequestData : ScriptableObject
{
    [SerializeField, Range(0, 100)] private float _exigence;

    [SerializeField] private CupSize _cupSize;
    [SerializeField, Range(0, 15)] private int _acidity;
    [SerializeField, Range(0, 15)] private int _sugar;
    [SerializeField, Range(0, 15)] private int _fruit;

    public bool AnswerRequest(BubbleTea tea)
    {
        if (tea == null)
            return false;

        int score = 0;
        if (tea.Size == _cupSize)
            score += tea.Config.CupScore;
        if (tea.Straw)
            score += tea.Config.StrawScore;

        float unaccuracy = 0;
        unaccuracy += Mathf.Abs(_acidity - tea.Acidity);
        unaccuracy += Mathf.Abs(_sugar - tea.Sugar);
        unaccuracy += Mathf.Abs(_fruit - tea.Fruit);
        
        score += (int)(100 - (unaccuracy / 45 * 100));

        return score >= _exigence;
    }
}
