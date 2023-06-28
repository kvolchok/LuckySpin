using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RouletteController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<float> _endSpinningEvent;

    private float _halfSectionSize => 360 / _sectionsCount / 2;

    [SerializeField]
    private SpinCounterController _spinCounter;
    [SerializeField]
    private Button _spinButton;
    [SerializeField]
    private GameObject _backlight;
    [SerializeField]
    private Transform _wheel;

    [SerializeField]
    private float _maxRotationTime;
    [SerializeField]
    private float _minRotationTime;
    [SerializeField]
    private float _maxRotationSpeed;
    [SerializeField]
    private float _minRotationSpeed;

    [SerializeField]
    private float _sectionsCount = 8;

    [UsedImplicitly]
    public void Spin()
    {
        _spinButton.enabled = false;
        _backlight.SetActive(true);
        _spinCounter.DecreaseCount();
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
        _endSpinningEvent?.Invoke((_wheel.eulerAngles.z + _halfSectionSize) % 360);
        _spinButton.enabled = true;
    }
}