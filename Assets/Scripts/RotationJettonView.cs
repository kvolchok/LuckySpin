using System.Collections;
using TMPro;
using UnityEngine;

public class RotationJettonView : MonoBehaviour
{
    private static readonly int _playFlyingAnimation = Animator.StringToHash("Play");
    
    [SerializeField]
    private TextMeshProUGUI _rotationsCountLabel;
    
    [SerializeField]
    private Transform _rotationJettonPrefab;
    [SerializeField]
    private Transform _canvasRoot;
    [SerializeField]
    private float _destructionDelay;

    public void SetScore(int value)
    {
        _rotationsCountLabel.text = value.ToString();
    }
    
    public void ChangeCount(int value)
    {
        SetScore(value);
        StartCoroutine(ShowFlyingJettonAnimation());
    }

    private IEnumerator ShowFlyingJettonAnimation()
    {
        var rotationJetton = Instantiate(_rotationJettonPrefab, _canvasRoot.transform);
        var animator = rotationJetton.GetComponent<Animator>();
        animator.SetTrigger(_playFlyingAnimation);

        yield return new WaitForSeconds(_destructionDelay);
        
        Destroy(rotationJetton.gameObject);
    }
}