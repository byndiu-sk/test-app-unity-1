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
        player.PlayerCar.speedEffector += Acceleration;
        GameController.Instance.ScoreManager.TurnNitroModifier();
    }

    public override void Cancel(Player player)
    {
        GameController.Instance.ScoreManager.TurnNitroModifier();
        player.PlayerCar.speedEffector -= Acceleration;
        base.Cancel(player);
    }
}
