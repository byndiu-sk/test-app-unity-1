using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private Image _fill;

    private void Awake()
    {
        _healthSystem.OnDamaged += OnDamaged;
    }

    private void OnDamaged(object sender, int e)
    {
        float healthPercentage = (float)e / _healthSystem.StartHealth;
        _fill.fillAmount = healthPercentage;
    }
}