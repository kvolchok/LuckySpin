using System.Collections;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _goldScoreLabel;
    [SerializeField]
    private TextMeshProUGUI _gemScoreLabel;
    
    [SerializeField]
    private float _moneyCalculationTime;

    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        
        SetScore(_goldScoreLabel, _wallet.GoldScore);
        SetScore(_gemScoreLabel, _wallet.GemScore);

        _wallet.GoldScoreChanged += OnGoldScoreChanged;
        _wallet.GemScoreChanged += OnGemScoreChanged;
    }
    
    private void SetScore(TextMeshProUGUI scoreLabel, int score)
    {
        scoreLabel.text = score.ToString();
    }

    private void OnGoldScoreChanged(int oldScore, int newScore)
    {
        StartCoroutine(ShowMoneyCalculationAnimation(_goldScoreLabel, oldScore, newScore));
    }
    
    private void OnGemScoreChanged(int oldScore, int newScore)
    {
        StartCoroutine(ShowMoneyCalculationAnimation(_gemScoreLabel, oldScore, newScore));
    }

    private IEnumerator ShowMoneyCalculationAnimation(TextMeshProUGUI scoreLabel, int oldScore, int newScore)
    {
        var currentTime = 0f;

        while (currentTime <= _moneyCalculationTime)
        {
            var progress = currentTime / _moneyCalculationTime;
            var currentScore = (int)Mathf.Lerp(oldScore, newScore, progress);
            currentTime += Time.deltaTime;
            SetScore(scoreLabel, currentScore);

            yield return null;
        }
        
        SetScore(scoreLabel, newScore);
    }

    private void OnDestroy()
    {
        _wallet.GoldScoreChanged -= OnGoldScoreChanged;
        _wallet.GemScoreChanged -= OnGemScoreChanged;
    }
}