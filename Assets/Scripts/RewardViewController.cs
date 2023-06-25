using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardViewController : MonoBehaviour
{
    [SerializeField]
    private RewardView[] _rewards;

    public void InitializeRewards(Dictionary<PrizeModel, int> prizes)
    {
        foreach (var (key, value) in prizes)
        {
            var reward = _rewards.First(reward => reward.Type == key.Type);
            reward.Initialize(value);
        }
    }
}