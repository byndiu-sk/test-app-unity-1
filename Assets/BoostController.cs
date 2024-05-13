using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    [SerializeField] private List<BoostItem> _boosts;

    private Player _player;
    
    private TemporaryBoostItem _currentBoost = null;
    private Coroutine _currentBoostRoutine = null;

    private void Awake()
    {
        _player = GameController.Instance.Player;
    }

    public void ActivateBoost(Boost item)
    {
        var newItem = _boosts.Find(x => x.Type == item.Type);
        
        if (newItem is TemporaryBoostItem)
        {
            _boosts.ForEach(b => b.gameObject.SetActive(false));
            
            var boost = _boosts.Find(b => b.Type == item.Type);
            if (boost != null)
                boost.gameObject.SetActive(true);
            
            TemporaryBoostItem newBoost = newItem as TemporaryBoostItem;
            if (_currentBoost != null)
            {
                // Has a current boost, remove it
                CancelBoost();
            }

            // Apply new boost
            newBoost.Apply(_player);
            _currentBoost = newBoost;
            
            _currentBoostRoutine = StartCoroutine(BoostRoutine(newBoost));
        }
        else
        {
            PermanentBoostItem permItem = newItem as PermanentBoostItem;
            permItem.Apply(_player);
            
        }
    }
    
    private IEnumerator BoostRoutine(TemporaryBoostItem item)
    {
        yield return new WaitForSeconds(item.Duration);
        CancelBoost();
    }
    
    public void CancelBoost()
    {
        if (_currentBoost != null)
        {
            StopCoroutine(_currentBoostRoutine);
            _currentBoost.Cancel(_player);
            _currentBoost = null;
        }
    }
    
    private void ActivateMagnetBoost()
    {
        // Code to activate magnet boost
    }
    private void ActivateShieldBoost()
    {
        // Code to activate shield boost
    }
    private void ActivateNitroBoost()
    {
        
    }

    private void ActivateHealthBoost(HealthItem item)
    {
        _player.HealthSystem.Heal(item.HP);

    }
    
}
