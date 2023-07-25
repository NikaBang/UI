using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        Slider.value = 1;
        _player.HealthChange += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChange -= OnValueChanged;
    }
}
