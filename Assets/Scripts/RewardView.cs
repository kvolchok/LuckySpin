using TMPro;
using UnityEngine;

public class RewardView : MonoBehaviour
{
    [field:SerializeField]
    public PrizeType Type { get; private set; }
    
    [SerializeField]
    private TextMeshProUGUI _valueLabel;
    private int _value;

    public void Initialize(int value)
    {
        _value += value;
        _valueLabel.text = _value.ToString();
    }
}