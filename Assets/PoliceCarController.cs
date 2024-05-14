using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private bool _isRunning = true;
    
    public bool IsRunning 
    { 
        get => _isRunning;
        set => _isRunning = value;
    }

    private void Start()
    {
        position = transform.position;
    }
    
    public void SetTarget(PlayerCarController player)
    {
        _target = player;
        _targetTransform = player.transform;
        Init();
    }
    
    public void Init()
    {
        _speed = _target.GetSpeed();
    }
    
    private void Update()
    {
        if (IsRunning)
        {
            if (_targetTransform.position.y > position.y)
            {
                position.y += (_speed + _speedOffset) * Time.deltaTime;
            }
            else
            {
                position.y += (_speed - _speedOffset) * Time.deltaTime;
            }
            
            float step = _horizontalSpeed * Time.deltaTime;
            position.x = Mathf.MoveTowards(position.x, _targetTransform.position.x, step);

            transform.position = position;
        }
    }
    
    public void StopRunning()
    {
        _isRunning = false;
        StartCoroutine(DestroyAfterSeconds(2));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("barrier hitted police");
        Barrier barrier = other.GetComponent<Barrier>();

        if (barrier != null)
        {
            StopRunning();
        }
    }

    private IEnumerator DestroyAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}