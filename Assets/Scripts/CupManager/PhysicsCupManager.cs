using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PhysicsCupManager : MonoBehaviour
{
    private static PhysicsCupManager _instance;
    public static PhysicsCupManager Instance => _instance;
    
    [SerializeField] private GameObject _Cup;
    [SerializeField] private GameObject _Tea;
    [SerializeField] private GameObject _Liquid;

    [SerializeField] private GameObject _BubblePrefab;

    void Awake()
    {
        _instance = this;
    }
    
    public async void FillBobaCup(IngredientData bubble)
    {
        IngredientBench.Instance.Hide();
        _Cup.SetActive(true);
        List<GameObject> bubbles = new List<GameObject>();
        for (int i = 0; i < (BubbleTeaManager.Instance.BubbleTea.Size == CupSize.Medium ? 20 : 30); i++) // Ouais trop bien les valeurs magiques en dur !
        {
            var nBubble = InstantiateAsync(_BubblePrefab, _Cup.transform.position + Vector3.up * 2.0f + Vector3.right * Mathf.Lerp(-0.7f, 0.7f, i / 20.0f),
                Quaternion.identity);
            float timer = 0.2f;
            while (!nBubble.isDone && timer > 0)
            {
                await Awaitable.EndOfFrameAsync();
                timer -= Time.deltaTime;
            }
            nBubble.Result[0].GetComponent<PhysicsBubble>().SetSprite(bubble.Sprite);
            bubbles.Add(nBubble.Result[0]);
        }

        await Awaitable.WaitForSecondsAsync(2.5f);
        foreach (GameObject b in bubbles)
        {
            b.transform.parent = _Cup.transform;
            b.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }

        Sequence seq = DOTween.Sequence();
        seq.Append(_Cup.transform.DOMoveX(-6, 1.0f));
        seq.Join(_Cup.transform.DOScale(Vector3.one * 0.5f, 0.5f));
        seq.AppendCallback(() => {         StateManager.Instance.ChangeState(new StateTeaSelection());});
    }

    public void FillTeaCup(IngredientData liquid)
    {
        _Tea.GetComponent<SpriteRenderer>().color = liquid.LiquidColor;
        IngredientBench.Instance.Hide();
        Sequence seq = DOTween.Sequence();
        seq.Append(_Cup.transform.DOMoveX(0, 1.0f));
        seq.Join(_Cup.transform.DOScale(Vector3.one * 1.0f, 0.5f));
        seq.Append(_Tea.transform.DOMoveY(0, 3.0f).SetEase(Ease.OutCirc));
        seq.AppendInterval(0.5f);
        seq.Append(_Cup.transform.DOMoveX(-6, 1.0f));
        seq.Join(_Cup.transform.DOScale(Vector3.one * 0.5f, 0.5f));
        seq.AppendCallback(() => { StateManager.Instance.ChangeState(new StateLiquidSelection());});
    }
    
    public void FillLiquidClient(IngredientData liquid)
    {
        _Liquid.GetComponent<SpriteRenderer>().color = liquid.LiquidColor;
        IngredientBench.Instance.Hide();
        Sequence seq = DOTween.Sequence();
        seq.Append(_Cup.transform.DOMoveX(0, 1.0f));
        seq.Join(_Cup.transform.DOScale(Vector3.one * 1.0f, 0.5f));
        seq.Append(_Liquid.transform.DOMoveY(0, 3.0f).SetEase(Ease.OutCirc));
        seq.AppendInterval(0.5f);
        seq.Append(_Cup.transform.DOMoveX(-6, 1.0f));
        seq.Join(_Cup.transform.DOScale(Vector3.one * 0.5f, 0.5f));
        seq.AppendCallback(() => { StateManager.Instance.ChangeState(new StateExtraSelection());});
    }
}
