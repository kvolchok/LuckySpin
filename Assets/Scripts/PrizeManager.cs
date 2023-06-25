using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PrizeManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<PrizeModel> _addPrizeEvent;
    
    [SerializeField]
    private PrizeModel[] _prizeModels;

    [SerializeField]
    private PrizeScreen _prizeScreenPrefab;
    [SerializeField]
    private PrizeScreen _prizeScreenTypeMoneyPrefab;
    [SerializeField]
    private PrizeScreen _prizeScreenTypeSkeletonPrefab;

    [SerializeField]
    private float _destroyDelay;

    public PrizeModel[] GetPrizeModels()
    {
        return _prizeModels;
    }
    
    public void AddPrize(float angle)
    {
        foreach (var prizeModel in _prizeModels)
        {
            if (angle < prizeModel.MinAngle || angle > prizeModel.MaxAngle)
            {
                continue;
            }
            
            switch (prizeModel.Type)
            {
                case PrizeType.Gold or PrizeType.Gem:
                {
                    var prizeScreenMoney = Instantiate(_prizeScreenTypeMoneyPrefab, transform);
                    prizeScreenMoney.Initialize(prizeModel);
                    _addPrizeEvent?.Invoke(prizeModel);
                    StartCoroutine(DestroyPrizeCoroutine(prizeScreenMoney));
                    break;
                }
                case PrizeType.Life or PrizeType.Relic:
                {
                    var prizeScreenItem = Instantiate(_prizeScreenPrefab, transform);
                    prizeScreenItem.Initialize(prizeModel);
                    _addPrizeEvent?.Invoke(prizeModel);
                    StartCoroutine(DestroyPrizeCoroutine(prizeScreenItem));
                    break;
                }
                case PrizeType.Skeleton:
                    var prizeScreenSkeleton = Instantiate(_prizeScreenTypeSkeletonPrefab, transform);
                    prizeScreenSkeleton.Initialize(prizeModel);
                    StartCoroutine(DestroyPrizeCoroutine(prizeScreenSkeleton));
                    break;
            }

            break;
        }
    }

    private IEnumerator DestroyPrizeCoroutine(PrizeScreen prizeScreen)
    {
        yield return new WaitForSeconds(_destroyDelay);
        
        Destroy(prizeScreen.gameObject);
    }
}