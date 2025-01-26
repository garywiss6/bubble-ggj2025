using System;
using UnityEngine;
using DG.Tweening;

public class PhysicsBubble : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _Renderer;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 normal = other.GetContact(0).normal;
        Vector2 rightNormal =   new Vector2(
            Mathf.Abs(normal.x * Mathf.Cos(90 * Mathf.Deg2Rad) - normal.y * Mathf.Sin(90 * Mathf.Deg2Rad)),
            Mathf.Abs(normal.x * Mathf.Sin(90 * Mathf.Deg2Rad) + normal.y * Mathf.Cos(90 * Mathf.Deg2Rad))
        );
        _Renderer.transform.DOComplete();
        _Renderer.transform.localScale = new Vector3(rightNormal.x, rightNormal.y, 1);
        _Renderer.transform.DOScale(Vector3.one, 0.2f);
    }
}
