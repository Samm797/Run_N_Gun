using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    
    public void Fire()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.transform.parent = transform.parent;
    }
}
