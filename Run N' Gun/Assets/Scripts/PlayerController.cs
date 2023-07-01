using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public static event Action OnPowersActivated;


    // Firing
    private Camera _camera;
    public GameObject power;

    // Movement
    private Rigidbody2D _rb;
    private Vector2 movement;
    [SerializeField] private float _activeMoveSpeed;

    // Animation
    private Animator _animator;

    // Vector shifting
    readonly VectorShift _shift = new VectorShift();

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Grabs input for both a controller and a keyboard and mouse
        // Could be in it's own function if wanted
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Handles the animation component
        AnimateMovement();

        // If the button is pressed 
        // "Fire1" Axis allows the use of both keyboard and controller right trigger (10th axis in input settings)
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            UnleashPowers();
        }
    }


    private void FixedUpdate()
    {
        // ActiveMoveSpeed is used in case we want to changed that later
        _rb.MovePosition(_rb.position + _activeMoveSpeed * Time.fixedDeltaTime * movement);
    }


    private void AnimateMovement()
    {
        // If the Vector2 that controls the movement is not (0,0), the player is walking
        // else, !walking
        if (movement != Vector2.zero)
        {
            _animator.SetBool("walking", true);
        }
        else
        {
            _animator.SetBool("walking", false);
        }
    }

    private void UnleashPowers()
    {
        // Will need to add a CD of some sort, but currently can be spammed

        // Event invoke if someone is listening
        OnPowersActivated?.Invoke();
        // Turn the gameObject (and therefore, the collider) active
        power.SetActive(true);
        // Turn it off shortly after
        StartCoroutine(PowersRoutine());
    }

    private IEnumerator PowersRoutine()
    {
        // Wait and then turn the gameObject (and therefore, the collider) inactive
        yield return new WaitForSeconds(0.3f);
        power.SetActive(false);
    }
}
