using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float _maxHealth = 10f;

    public float _currentHealth { get; set; }

    public float getRatio() => _currentHealth / _maxHealth;


    bool _isDead;
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float healAmount)
    {
        _currentHealth += healAmount;

        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);

    }

    public void TakeDamage(float damage)
    {
        _currentHealth += damage;

        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);

        HandleDeath();
    }
    private void HandleDeath()
    {
        if (_isDead)
            return;
        if (_currentHealth <= 0f)
        {
            _isDead = true;
        }
    }
}
