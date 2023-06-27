using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<int, int> GoldScoreChanged;
    public event Action<int, int> GemScoreChanged; 

    [field:SerializeField]
    public int GoldScore { get; private set; }
    [field:SerializeField]
    public int GemScore { get; private set; }

    public void AddGoldScore(int delta)
    {
        var oldScore = GoldScore;
        GoldScore += delta;
        
        GoldScoreChanged?.Invoke(oldScore, GoldScore);
    }
    public void AddGemScore(int delta)
    {
        var oldScore = GemScore;
        GemScore += delta;
        
        GemScoreChanged?.Invoke(oldScore, GemScore);
    }
}