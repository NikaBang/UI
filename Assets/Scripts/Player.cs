using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private HealthBar _healthBar;

    private int _currentHealth;
    private int _scorPoints = 10;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }
    public void ApplyDamage()
    {
        _currentHealth -= _scorPoints;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void ApplyHealed()
    {
        _currentHealth += _scorPoints;
        _healthBar.OnValueChanged(_currentHealth, _health);

        if (_currentHealth >= _health)
        {
            _currentHealth = _health;
        }
    }
}
