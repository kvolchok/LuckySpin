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

    private SpinCounterController _spinCounterController;

    public void Initialize(SpinCounterController spinCounterController)
    {
        _spinCounterController = spinCounterController;
        
        SetScore(_spinCounterController.RotationsCount);

        _spinCounterController.OnCountChanged += ChangeCount;
    }

    private void SetScore(int count)
    {
        _rotationsCountLabel.text = count.ToString();
    }
    
    private void ChangeCount(int count)
    {
        SetScore(count);
        
        var jetton = Instantiate(_jettonPrefab, _canvasRoot.transform);
        jetton.Fly();
    }

    private void OnDestroy()
    {
        _spinCounterController.OnCountChanged -= ChangeCount;
    }
}