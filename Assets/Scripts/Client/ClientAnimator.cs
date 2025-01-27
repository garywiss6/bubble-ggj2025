using UnityEditor.Animations;
using UnityEngine;

public class ClientAnimator : SingletonBehaviour<ClientAnimator>
{
    [SerializeField] private Animator _animator;
    public event DelegateDefinition.void_D_void _trigger;
    public void SetState(int state)
    {
        _animator.SetInteger("InteractionState", state);
    }

    public void SetTalk(bool state)
    {
        _animator.SetBool("IsTalking", state);
    }

    public void SetController(AnimatorController controller)
    {
        _animator.runtimeAnimatorController = controller;
        SetState(1);
    }

    public void Trigger()
    {
        _animator.SetTrigger("Trigger");
    }

    public void TakeASip()
    {
        SetState(2);
        SetTalk(false);
    }

    public void OnArrival()
    {
        _trigger?.Invoke();
    }
}
