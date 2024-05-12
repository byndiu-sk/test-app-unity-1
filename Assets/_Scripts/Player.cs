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

    private void Start()
    {
        print("player is active");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("triggered");
        Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            _healthSystem.Damage(obstacle.HitDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("on collision");
    }
}
