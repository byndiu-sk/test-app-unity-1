using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoostItem : MonoBehaviour
{
    [SerializeField] private BoostType _type;
    
    public BoostType Type => _type;

    public void Pickup()
    {
        gameObject.SetActive(false);
    }
}