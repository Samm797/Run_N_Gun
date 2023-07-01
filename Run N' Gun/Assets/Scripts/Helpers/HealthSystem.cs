using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int CurrentHealth => _currentHealth;
    public int maxHealth;

    private int _currentHealth;

    private void Start()
    {
        // Set current health to the maxhealth
        _currentHealth = maxHealth;
    }

    public void Damage()
    {
        // Take one damage and ensure this value does not go below 0
        _currentHealth--;

        if (_currentHealth < 0 )
        {
            _currentHealth = 0;
        }
    }
}
