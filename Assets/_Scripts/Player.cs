using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void OnCollisionEnter(Collision other)
    {
        
        Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            _healthSystem.Damage(obstacle.HitDamage);
        }
        
    }
}
