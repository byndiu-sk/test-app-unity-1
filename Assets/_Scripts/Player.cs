using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private BoostController _boostController;
    private PlayerCarController _playerCar;
    private Coroutine _activeBoostRoutine;

    public PlayerCarController PlayerCar => _playerCar;
    public HealthSystem HealthSystem => _healthSystem;
    

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
        Boost boostItem = other.gameObject.GetComponent<Boost>();

        if (obstacle != null)
        {
            _healthSystem.Damage(obstacle.HitDamage);
            StartCoroutine(SlowDownPlayer(obstacle));
        }

        if (boostItem != null)
        {
            ActivateItem(boostItem);
        }
    }


    private void ActivateItem(Boost item)
    {
        item.Pickup();
        _boostController.ActivateBoost(item);
    }
    

    public IEnumerator SlowDownPlayer(Obstacle obstacle)
    {
        _playerCar.speedAffector -= obstacle.Deceleration;
        yield return new WaitForSeconds(10);
        _playerCar.speedAffector += obstacle.Deceleration;
    }
}
