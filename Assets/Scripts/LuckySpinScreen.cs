using UnityEngine;

public class LuckySpinScreen : MonoBehaviour
{
    [SerializeField]
    private RotationJettonManager _rotationJettonManager;
    [SerializeField]
    private RotationJettonView _rotationJettonView;

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
        _rotationJettonView.SetScore(_rotationJettonManager.RotationsCount);
        _rotationJettonManager.Initialize(_rotationJettonView.ChangeCount);

        var prizeModels = _prizeManager.GetPrizeModels();
        _chest.Initialize(prizeModels, _walletManager.AddGoldScore, _walletManager.AddGemScore);
        
        _walletManager.Initialize(_walletView.AddScore);
    }
}