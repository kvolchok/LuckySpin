using JetBrains.Annotations;
using UnityEngine;

public class FlyingJetton : MonoBehaviour
{
    private static readonly int _flyKey = Animator.StringToHash("Fly");
    
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _destructionDelay;

    public void Fly()
    {
        _animator.SetTrigger(_flyKey);
    }

    [UsedImplicitly]
    private void DestroyJetton()
    {
        Destroy(gameObject);
    }
}