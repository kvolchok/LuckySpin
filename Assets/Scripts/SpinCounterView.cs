using TMPro;
using UnityEngine;

public class SpinCounterView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _rotationsCountLabel;
    
    [SerializeField]
    private FlyingJetton _jettonPrefab;
    [SerializeField]
    private Transform _canvasRoot;

    public void ChangeCount(int value)
    {
        SetScore(value);
        
        var jetton = Instantiate(_jettonPrefab, _canvasRoot.transform);
        jetton.Fly();
    }
    
    public void SetScore(int value)
    {
        _rotationsCountLabel.text = value.ToString();
    }
}