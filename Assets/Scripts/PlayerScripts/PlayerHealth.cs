using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health;
    private int _maxHealth = 10;

    public event Action<int> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_maxHealth);
    }

    public void OnHealthChanged(int healthChangeValue)
    {
       _health = Mathf.Clamp(_health + healthChangeValue, 0, _maxHealth);      
        HealthChanged?.Invoke(_health);
    }
}
