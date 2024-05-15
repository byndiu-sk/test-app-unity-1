using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : PermanentBoostItem
{
    [SerializeField] private float value = 100;
    public override void Apply(Player player)
    {
        GameController.Instance.ScoreManager.AddScore(value);
    }
}
