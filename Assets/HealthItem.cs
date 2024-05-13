using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : PermanentBoostItem
{
    [SerializeField] private float _hp;
    
    public float HP
    {
        get { return _hp; }
    }

    public override void Apply(Player player)
    {
        player.HealthSystem.Heal(_hp);
    }
}
