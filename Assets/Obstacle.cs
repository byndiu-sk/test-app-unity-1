using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _hitDamage;
    
    public int HitDamage
    {
        get => _hitDamage;
    }
}
