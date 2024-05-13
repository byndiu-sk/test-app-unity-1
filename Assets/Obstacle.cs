using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _hitDamage;
    [SerializeField] private float _deceleration;
    
    public int HitDamage
    {
        get => _hitDamage;
    }

    public float Deceleration => _deceleration;
}


