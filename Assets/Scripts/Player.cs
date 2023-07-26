using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private HealthBar _healthBar;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
    }
    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.OnValueChanged(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void ApplyHealed(int healed)
    {
        _currentHealth += healed;
        _healthBar.OnValueChanged(_currentHealth, _health);

        if (_currentHealth >= _health)
        {
            _currentHealth = _health;
        }
    }
}
