using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoDestroyOnDistance : MonoBehaviour
{
    private float _distance;
    private Vector3 _player;
    [SerializeField] private float _destroyDistance;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>().position;
    }

    private void Update()
    {
        _distance = Vector3.Distance(_player, transform.position);
        
        if (_distance > _destroyDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
