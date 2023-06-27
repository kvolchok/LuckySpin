using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private static readonly int _putPrize = Animator.StringToHash("Put Prize");
    private static readonly int _move = Animator.StringToHash("Move");
    private static readonly int _open = Animator.StringToHash("Open");
    private static readonly int _hide = Animator.StringToHash("Hide");

    [SerializeField]
    private RewardViewController _rewardsController;
    
    [SerializeField]
    private float _putPrizeAnimationDelay;
    [SerializeField]
    private float _moveChestAnimationDelay;

    private Animator _animator;

    public void Initialize(Wallet wallet)
    {
        _rewardsController.Initialize(wallet);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Add(PrizeModel prizeModel)
    {
        StartCoroutine(ShowPutPrizeAnimation());
        _rewardsController.Add(prizeModel);
    }
    
    public void TakePrizes()
    {
        StartCoroutine(ShowMoveChestAnimation());
    }

    [UsedImplicitly]
    public void Open()
    {
        _animator.SetTrigger(_open);

        _rewardsController.ShowRewards();
    }

    [UsedImplicitly]
    public void Claim()
    {
        _animator.SetTrigger(_hide);

        _rewardsController.ClaimRewards();
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