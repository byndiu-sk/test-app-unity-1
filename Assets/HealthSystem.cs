using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _startHealth;
    
    private float _currentHealth;
    
    public float StartHealth
    {
        get => _startHealth;
    }

    public EventHandler<float> OnDamaged;
    public Action OnCrashed;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _currentHealth = _startHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Damage(10);
        }
    }

    public void Damage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        
        OnDamaged?.Invoke(this, _currentHealth);
        print("car was damaged");
        
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            
            OnCrashed?.Invoke();
            GameController.Instance.EndGame();
            print("car was crashed");
        }
    }

    public void Heal(float healAmount)
    {
        _currentHealth += healAmount;
        OnDamaged?.Invoke(this, _currentHealth);
    }

    public float GetHealth()
    {
        return _currentHealth;
    }
}