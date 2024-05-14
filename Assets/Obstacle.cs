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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        ShieldBoostItem shield = other.gameObject.GetComponent<ShieldBoostItem>();
        
        if (shield != null)
        {
            print("shield was activated");
            Destroy(gameObject);
        }
    }
}


