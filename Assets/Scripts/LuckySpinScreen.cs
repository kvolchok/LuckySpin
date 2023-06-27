using UnityEngine;

public class LuckySpinScreen : MonoBehaviour
{
    [SerializeField]
    private SpinCounterController _spinCounterController;
    [SerializeField]
    private SpinCounterView _spinCounterView;

    [SerializeField]
    private PrizeManager _prizeManager;
    [SerializeField]
    private Chest _chest;

    [SerializeField]
    private WalletManager _walletManager;
    [SerializeField]
    private WalletView _walletView;

    private void Awake()
    {
        _spinCounterView.Initialize(_spinCounterController);

        var prizeModels = _prizeManager.GetPrizeModels();
        _chest.Initialize(prizeModels, _walletManager.AddGoldScore, _walletManager.AddGemScore);
        
        _walletManager.Initialize(_walletView.AddScore);
    }
}