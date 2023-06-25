using System.Collections;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _goldValueLabel;
    [SerializeField]
    private TextMeshProUGUI _gemValueLabel;
    
    [SerializeField]
    private float _moneyCalculationTime;

    public void SetStartScore(int goldValue, int gemValue)
    {
        SetScore(_goldValueLabel, goldValue);
        SetScore(_gemValueLabel, gemValue);
    }

    public void AddScore(PrizeModel prizeModel, int startMoneyScore, int delta)
    {
        switch (prizeModel.Type)
        {
            case PrizeType.Gold:
                StartCoroutine(ShowMoneyCalculationAnimation(_goldValueLabel, startMoneyScore, delta));
                break;
            case PrizeType.Gem:
                StartCoroutine(ShowMoneyCalculationAnimation(_gemValueLabel, startMoneyScore, delta));
                break;
        }
    }

    private void SetScore(TextMeshProUGUI moneyValueLabel, int moneyScore)
    {
        moneyValueLabel.text = moneyScore.ToString();
    }

    private IEnumerator ShowMoneyCalculationAnimation(TextMeshProUGUI moneyValueLabel, int startMoneyScore, int delta)
    {
        var newMoneyScore = startMoneyScore + delta;
        var currentTime = 0f;

        while (currentTime <= _moneyCalculationTime)
        {
            var progress = currentTime / _moneyCalculationTime;
            var currentScore = (int)Mathf.Lerp(startMoneyScore, newMoneyScore, progress);
            currentTime += Time.deltaTime;
            SetScore(moneyValueLabel, currentScore);

            yield return null;
        }
        
        SetScore(moneyValueLabel, newMoneyScore);
    }
}