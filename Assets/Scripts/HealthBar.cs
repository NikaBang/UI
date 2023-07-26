using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _recoveryRate;

    private Coroutine _current;
    private float _target;

    private void OnEnable()
    {
        _slider.value = 1;
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    public void OnValueChanged(int value, int maxValue)
    {
        _target = (float)value / maxValue;
        StartState(MoveTowards());
    }

    private IEnumerator MoveTowards()
    {
        while (_slider.value != _target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _target, _recoveryRate);
            
            yield return null;
        }
    }

    private void StartState(IEnumerator coroutine)
    {
        if (_current != null)
            StopCoroutine(_current);

        _current = StartCoroutine(coroutine);
    }
}