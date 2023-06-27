using System;
using UnityEngine;
using UnityEngine.Events;

public class SpinCounterController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _zeroCountEvent;
    public event Action<int> OnCountChanged;
    
    [field:SerializeField]
    public int RotationsCount { get; private set; }

    public void DecreaseCount()
    {
        RotationsCount--;
        OnCountChanged?.Invoke(RotationsCount);
        
        if (RotationsCount <= 0)
        {
            _zeroCountEvent?.Invoke();
        }
    }
}