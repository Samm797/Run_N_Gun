using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D _rb;
    private Vector2 _moveDir;

    private bool _isMoving = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _rb.MovePosition(_rb.position + (Time.fixedDeltaTime * moveSpeed * _moveDir));
        }
        else
        {
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0f;
        }
    }

    public void MoveTo(Vector2 targetPosition)
    {
        _isMoving = true;
        _moveDir = targetPosition;
    }

    public void StopMoving()
    {
        _isMoving = false;
    }
}
