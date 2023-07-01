using System;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class EnemyAI : MonoBehaviour
{
    public static event Action OnKilled;

    private enum State
    {
        Idle,
        Searching,
        Aware, 
        Attacking
    }

    private State _state;
    private HealthSystem _healthSystem;
    /// <summary>
    /// 0 = Pistol;
    /// </summary>
    [SerializeField] private int _enemyID;

    private void OnEnable()
    {
        OnKilled += Death;
    }

    private void OnDisable()
    {
        OnKilled -= Death;
    }

    private void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void Update()
    {
        if (_healthSystem.CurrentHealth <= 0)
        {
            // Calls the OnKilled event, which will trigger the Death() method
            OnKilled?.Invoke();
        }
    }

    private void Death()
    {
        // Death Animation
        Debug.Log("We ded.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player's power hits the enemies' collider, take damage
        if (other.CompareTag("Power"))
        {
            _healthSystem.Damage();
        }
    }
}
