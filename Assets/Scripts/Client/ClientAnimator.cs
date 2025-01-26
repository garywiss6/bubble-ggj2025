using UnityEngine;

public class ClientAnimator : SingletonBehaviour<ClientAnimator>
{
    [SerializeField] private Animator _animator;
    public event DelegateDefinition.void_D_void _trigger;
    public void SetState(int state)
    {
        _animator.SetInteger("InteractionState", state);
    }

    public void Trigger()
    {
        _animator.SetTrigger("Trigger");
    }

    public void OnArrival()
    {
        _trigger?.Invoke();
    }
}
