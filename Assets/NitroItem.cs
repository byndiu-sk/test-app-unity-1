using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroItem : TemporaryBoostItem
{
    [SerializeField] private float _acceleration;

    public float Acceleration => _acceleration;
    public override void Apply(Player player)
    {
        base.Apply(player);
        player.PlayerCar.speedAffector += Acceleration;
    }

    public override void Cancel(Player player)
    {
        player.PlayerCar.speedAffector -= Acceleration;
        base.Cancel(player);
    }
}
