using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    
    private int _currentHealth;
    
    public int StartHealth
    {
        get => _startHealth;
    }

    public EventHandler<int> OnDamaged;
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

    public void Damage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        
        OnDamaged?.Invoke(this, _currentHealth);
        print("car was damaged");
        
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            
            OnCrashed?.Invoke();
            print("car was crashed");
        }
    }

    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;
    }

    public int GetHealth()
    {
        return _currentHealth;
    }
}