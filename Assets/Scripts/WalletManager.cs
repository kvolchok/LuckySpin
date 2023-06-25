using System;
using UnityEngine;
using UnityEngine.Events;

public class WalletManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int, int> _setStartScoreEvent;
    private Action<PrizeModel, int, int> _increaseScoreEvent;

    [SerializeField]
    private int _goldScore;
    [SerializeField]
    private int _gemScore;

    public void Initialize(Action<PrizeModel, int, int> increaseScoreEvent)
    {
        _increaseScoreEvent = increaseScoreEvent;
        
        _setStartScoreEvent?.Invoke(_goldScore, _gemScore);
    }
    
    public void AddGoldScore(PrizeModel prizeModel, int value)
    {
        _increaseScoreEvent?.Invoke(prizeModel, _goldScore, value);
        _goldScore += value;
    }
    public void AddGemScore(PrizeModel prizeModel, int value)
    {
        _increaseScoreEvent?.Invoke(prizeModel, _gemScore, value);
        _gemScore += value;
    }
}