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
            StartCoroutine(SlowDownPlayer(obstacle));
        }

        if (boostItem != null)
        {
            boostItem.Pickup();
            _boostController.SetActiveBoost(boostItem.Type);
            ActivateItem(boostItem);
        }
    }


    private void ActivateItem(BoostItem item)
    {
        switch (item.Type)
        {
            case BoostType.Health:
                ActivateHealthItem(item as HealthItem);
                break;
        }
    }

    private void ActivateHealthItem(HealthItem item)
    {
        _healthSystem.Heal(item.HP);
    }

    public IEnumerator SlowDownPlayer(Obstacle obstacle)
    {
        _playerCar.speedAffector -= obstacle.Deceleration;
        yield return new WaitForSeconds(10);
        _playerCar.speedAffector += obstacle.Deceleration;
    }
}
