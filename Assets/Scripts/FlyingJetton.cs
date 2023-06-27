using System.Collections;
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
        StartCoroutine(ShowFlyingAnimation());
    }
    
    private IEnumerator ShowFlyingAnimation()
    {
        _animator.SetTrigger(_flyKey);

        yield return new WaitForSeconds(_destructionDelay);
        
        Destroy(gameObject);
    }
}