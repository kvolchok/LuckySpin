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
        foreach (var reward in _rewards)
        {
            if (reward.Value == 0)
            {
                continue;
            }
            
            switch (reward.Type)
            {
                case PrizeType.Gold:
                    _wallet.AddGoldScore(reward.Value);
                    break;
                case PrizeType.Gem:
                    _wallet.AddGemScore(reward.Value);
                    break;
            }
        }
    }
}