using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _damage;
    [SerializeField] private int _haelth;

    public void ClickHealth()
    {
        _player.ApplyHealed(_haelth);
    }

    public void ClickDamage()
    {
        _player.ApplyDamage(_damage);
    }
}
