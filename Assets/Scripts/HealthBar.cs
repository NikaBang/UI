using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _recoveryRate;

    private float _targetValue;

    private void Start()
    {
        _slider.value = _slider.maxValue;
        _targetValue = _slider.value;
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _recoveryRate * Time.deltaTime);
    }

    public void OnValueChanged(int value, int maxValue)
    {
        _targetValue = (float)value / maxValue;
    }
}