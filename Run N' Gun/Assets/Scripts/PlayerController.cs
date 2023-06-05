using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [Header("Firing")]
    private Camera _camera;
    public GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;

    [Header("Movement")]
    private float _horizontalInput, _verticalInput;
    [SerializeField] private float _activeMoveSpeed;
    private Rigidbody2D _rb;

    // Vector shifting
    VectorShift _shift = new VectorShift();


    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(_horizontalInput, _verticalInput) * _activeMoveSpeed;
        _rb.velocity = movement; 

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector3 difference = mousePos - transform.position;
            float distance = difference.magnitude;
            Vector3 direction = (difference / distance).normalized;

            FireShotgun(direction, _bulletSpeed);
        }
    }

    private void FireShotgun(Vector3 direction, float speed)
    {
        Vector3 leftDirection = _shift.ZShiftVectorXDegreesLeft(direction, true, 12);
        Vector3 rightDirection = _shift.ZShiftVectorXDegreesLeft(direction, false, 12);


        GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;

        GameObject leftBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        leftBullet.GetComponent<Rigidbody2D>().velocity = leftDirection * speed;

        GameObject rightBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        rightBullet.GetComponent<Rigidbody2D>().velocity = rightDirection * speed;
    }
}
