using System;
using UnityEngine;
using UnityEngine.Events;

public class RotationJettonManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _zeroCountEvent;
    private Action<int> _changeCountEvent;
    
    [field:SerializeField]
    public int RotationsCount { get; private set; }

    public void Initialize(Action<int> changeCountEvent)
    {
        _changeCountEvent = changeCountEvent;
    }
    
    public void DecreaseCount()
    {
        RotationsCount--;
        _changeCountEvent?.Invoke(RotationsCount);
        
        if (RotationsCount <= 0)
        {
            _zeroCountEvent?.Invoke();
        }
    }
}