using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    [SerializeField] private List<Boost> _boosts;
    
    public void SetActiveBoost(BoostType type)
    {
        _boosts.ForEach(b => b.gameObject.SetActive(false));
        
        var boost = _boosts.Find(b => b.Type == type);
        boost.gameObject.SetActive(true);
    }
}
