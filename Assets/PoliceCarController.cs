using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PoliceCarController : MonoBehaviour
{
    [SerializeField] private float _speedOffset;
    private float _speed;
    [SerializeField] private float _horizontalSpeed;
    
    private PlayerCarController _target;
    private Transform _targetTransform;
    private Vector3 position;

    public void SetTarget(PlayerCarController player)
    {
        _target = player;
        _targetTransform = player.transform;
        Init();
    }

    private void Start()
    {
        position = transform.position;
    }

    private void Update()
    {
        if (_targetTransform.position.y > position.y)
        {
            position.y += (_speed + _speedOffset) * Time.deltaTime;
        }
        else
        {
            position.y += (_speed - _speedOffset) * Time.deltaTime;
        }

        // Approach the target horizontally
        float step = _horizontalSpeed * Time.deltaTime;
        position.x = Mathf.MoveTowards(position.x, _targetTransform.position.x, step);

        transform.position = position;
    }

    public void Init()
    {
        _speed = _target.speed;
    }
}