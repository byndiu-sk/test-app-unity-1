using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Image _fill;
    
    public void SetFillAmount(float amount)
    {
        _fill.fillAmount = amount;
    }
}