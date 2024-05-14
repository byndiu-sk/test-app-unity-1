using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : TemporaryBoostItem
{
    [SerializeField] private float _strength = 10f;
    [SerializeField] private float _radius = 1f;

    private void FixedUpdate()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach (var obj in objects)
        {
            if(obj.TryGetComponent(out CoinBoost coin))
            {
                Vector2 direction = (Vector2)coin.transform.position - (Vector2)transform.position;
                direction.Normalize();

                coin.GetComponent<Rigidbody2D>().AddForce(-direction * _strength);
            }
        }
    }
    public override void Apply(Player player)
    {
        base.Apply(player);
        print("magnet applied");
    }

    public override void Cancel(Player player)
    {
        base.Cancel(player);
        print("magnet canceled");
    }
}
