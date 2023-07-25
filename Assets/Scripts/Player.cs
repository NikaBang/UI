using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    public event UnityAction<int, int> HealthChange;

    private void Start()
    {
        _currentHealth = _health;
    }
    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChange?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void ApplyHealed(int healed)
    {
        _currentHealth += healed;
        HealthChange?.Invoke(_currentHealth, _health);

        if (_currentHealth >= _health)
        {
            _currentHealth = _health;
        }
    }
}
