using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardViewController : MonoBehaviour
{
    [SerializeField]
    private RewardView[] _rewards;
    
    private readonly List<PrizeModel> _prizes = new();
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
    }
    
    public void Add(PrizeModel model)
    {
        _prizes.Add(model);
    }
    
    public void ShowRewards()
    {
        foreach (var prize in _prizes)
        {
            var reward = _rewards.First(reward => reward.Type == prize.Type);
            reward.Initialize(prize.Value);
        }
    }
    
    public void ClaimRewards()
    {
        foreach (var prize in _prizes)
        {
            if (prize.Value == 0)
            {
                continue;
            }
            
            switch (prize.Type)
            {
                case PrizeType.Gold:
                    _wallet.AddGoldScore(prize, prize.Value);
                    break;
                case PrizeType.Gem:
                    _wallet.AddGemScore(prize, prize.Value);
                    break;
            }
        }
    }
}