using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PrizeManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<PrizeModel> _addPrizeEvent;
    
    [SerializeField]
    private PrizeModel[] _prizeModels;
    [SerializeField]
    private PrizeScreenByType[] _prizeScreens;

    public void AddPrize(float angle)
    {
        foreach (var model in _prizeModels)
        {
            if (angle < model.MinAngle || angle > model.MaxAngle)
            {
                continue;
            }
            
            ShowScreen(model);
            break;
        }
    }

    private void ShowScreen(PrizeModel model)
    {
        var screenByType = _prizeScreens.First(screenByType => screenByType.Type == model.Type);
        var screen = Instantiate(screenByType.Screen, transform);
        screen.Initialize(model);

        if (screenByType.Type != PrizeType.Skeleton)
        {
            _addPrizeEvent?.Invoke(model);
        }
    }
}