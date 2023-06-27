using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Dictionary<PrizeModel, int>> _openChestEvent;

    private Action<PrizeModel, int> _claimGoldEvent;
    private Action<PrizeModel, int> _claimGemsEvent;
    
    private static readonly int _putPrize = Animator.StringToHash("Put Prize");
    private static readonly int _move = Animator.StringToHash("Move");
    private static readonly int _open = Animator.StringToHash("Open");
    private static readonly int _hide = Animator.StringToHash("Hide");

    private readonly Dictionary<PrizeModel, int> _prizes = new();
    
    [SerializeField]
    private float _putPrizeAnimationDelay;
    [SerializeField]
    private float _moveChestAnimationDelay;

    private Animator _animator;

    public void Initialize(PrizeModel[] prizeModels,
        Action<PrizeModel, int> claimGoldEvent, Action<PrizeModel, int> claimGemsEvent)
    {
        foreach (var prizeModel in prizeModels)
        {
            if (prizeModel.Type == PrizeType.Skeleton)
            {
                continue;
            }

            _prizes.Add(prizeModel, 0); 
        }

        _claimGoldEvent = claimGoldEvent;
        _claimGemsEvent = claimGemsEvent;
        
        _animator = GetComponent<Animator>();
    }

    public void Add(PrizeModel prizeModel)
    {
        StartCoroutine(ShowPutPrizeAnimation());
        _prizes[prizeModel] += prizeModel.Value;
    }
    
    public void TakePrizes()
    {
        StartCoroutine(ShowMoveChestAnimation());
    }

    [UsedImplicitly]
    public void Open()
    {
        _animator.SetTrigger(_open);

        _openChestEvent?.Invoke(_prizes);
    }

    public void Claim()
    {
        _animator.SetTrigger(_hide);

        foreach (var (key, value) in _prizes)
        {
            if (value == 0)
            {
                continue;
            }
            
            switch (key.Type)
            {
                case PrizeType.Gold:
                    _claimGoldEvent?.Invoke(key, value);
                    break;
                case PrizeType.Gem:
                    _claimGemsEvent?.Invoke(key, value);
                    break;
            }
        }
    }

    private IEnumerator ShowPutPrizeAnimation()
    {
        yield return new WaitForSeconds(_putPrizeAnimationDelay);
        
        _animator.SetTrigger(_putPrize);
    }
    
    private IEnumerator ShowMoveChestAnimation()
    {
        yield return new WaitForSeconds(_moveChestAnimationDelay);
        
        _animator.SetTrigger(_move);
    }
}