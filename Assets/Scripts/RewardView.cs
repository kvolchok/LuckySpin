using TMPro;
using UnityEngine;

public class RewardView : MonoBehaviour
{
    [field:SerializeField]
    public PrizeType Type { get; private set; }
    public int Value { get; private set; }
    
    [SerializeField]
    private TextMeshProUGUI _valueLabel;

    public void Initialize(int value)
    {
        Value += value;
        _valueLabel.text = Value.ToString();
    }
}