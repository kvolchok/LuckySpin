using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrizeScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private TextMeshProUGUI _value;

    public void Initialize(PrizeModel prizeModel)
    {
        _name.text = prizeModel.Name;
        _icon.sprite = prizeModel.Icon;
        _value.text = prizeModel.Value.ToString();
    }
}