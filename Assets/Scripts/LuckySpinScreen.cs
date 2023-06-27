using UnityEngine;

public class LuckySpinScreen : MonoBehaviour
{
    [SerializeField]
    private SpinCounterController _spinCounterController;
    [SerializeField]
    private SpinCounterView _spinCounterView;
    
    [SerializeField]
    private Chest _chest;

    [SerializeField]
    private Wallet _wallet;
    [SerializeField]
    private WalletView _walletView;

    private void Awake()
    {
        _spinCounterView.Initialize(_spinCounterController);
        _walletView.Initialize(_wallet);
        _chest.Initialize(_wallet);
    }
}