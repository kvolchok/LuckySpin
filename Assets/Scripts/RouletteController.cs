using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class RouletteController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _spinEvent;
    [SerializeField]
    private UnityEvent<float> _endSpinningEvent;
    
    [SerializeField]
    private Transform _wheel;
    [SerializeField]
    private GameObject _backlight;

    [SerializeField]
    private float _maxRotationTime;
    [SerializeField]
    private float _minRotationTime;
    [SerializeField]
    private float _maxRotationSpeed;
    [SerializeField]
    private float _minRotationSpeed;

    [SerializeField]
    private float _wheelRotationDelta = 22.5f;

    [UsedImplicitly]
    public void Spin()
    {
        _backlight.SetActive(true);
        _spinEvent?.Invoke();
        StartCoroutine(SpinCoroutine());
    }

    private IEnumerator SpinCoroutine()
    {
        var randomSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
        var force = Vector3.forward * randomSpeed;
        var randomRotationTime = Random.Range(_minRotationTime, _maxRotationTime);
        var currentTime = 0f;

        while (currentTime <= randomRotationTime)
        {
            var progress = currentTime / randomRotationTime;
            var currentRotation = Vector3.Lerp(force, Vector3.zero, progress);
            _wheel.Rotate(currentRotation);
            currentTime += Time.deltaTime;

            yield return null;
        }
        
        _backlight.SetActive(false);
        _endSpinningEvent?.Invoke((_wheel.eulerAngles.z + _wheelRotationDelta) % 360);
    }
}