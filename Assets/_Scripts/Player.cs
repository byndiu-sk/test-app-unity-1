using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private BoostController _boostController;
    private PlayerCarController _playerCar;

    public PlayerCarController PlayerCar => _playerCar;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _boostController = GetComponent<BoostController>();
        _playerCar = GetComponentInChildren<PlayerCarController>();
    }

    private void Start()
    {
        print("player is active");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("triggered");
        Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
        BoostItem boostItem = other.gameObject.GetComponent<BoostItem>();

        if (obstacle != null)
        {
            _healthSystem.Damage(obstacle.HitDamage);
        }

        if (boostItem != null)
        {
            boostItem.Pickup();
            _boostController.SetActiveBoost(boostItem.Type);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("on collision");
    }
}
