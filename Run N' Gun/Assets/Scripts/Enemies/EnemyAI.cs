using System;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(EnemyPathfinding))]
public class EnemyAI : MonoBehaviour, IDamagable
{
    public static event Action OnKilled;

    private enum State
    {
        Idle,
        Patrol,
        Aware, 
        Attacking,
        Dead
    }

    private State _state;
    private EnemyPathfinding _enemyPathfinding;
    private HealthSystem _healthSystem;
    private Animator _animator;
    private Weapon _weapon;
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

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _animator = GetComponent<Animator>();
        _enemyPathfinding = GetComponent<EnemyPathfinding>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (_state == State.Dead) return;
        
        if (_healthSystem.CurrentHealth <= 0)
        {
            // Calls the OnKilled event, which will trigger the Death() method and other methods later
            OnKilled?.Invoke();
        }

        switch(_state)
        {
            case State.Idle:
                break;
            case State.Patrol:
                break;
            case State.Aware:
                break;
            case State.Attacking:
                break;
        }
    }
    // Must be implemented because of the IDamagable interface
    // Calls the damage function found on the health system
    public void Damage()
    {
        _healthSystem.Damage();
    }

    private void Death()
    {
        // Death Animation? 
        _enemyPathfinding.StopMoving();
        _state = State.Dead;
        Debug.Log("We ded.");
    }

    private void FireWeapon()
    {
        _weapon.Fire();
    }

}
