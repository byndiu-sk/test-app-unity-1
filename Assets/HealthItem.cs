using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : BoostItem
{
    [SerializeField] private float _hp;
    
    public float HP
    {
        get { return _hp; }
    }
}
