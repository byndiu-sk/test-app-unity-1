using UnityEngine;

public abstract class TemporaryBoostItem : BoostItem
{
    [SerializeField] private float _duration;
    [SerializeField] protected Bar _bar;

    private float _timer = 0f; 
    
    public float Duration => _duration;
    
    void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
            
            _bar.SetFillAmount(GetInterpolatedValue());
        }
    }
    
    public virtual void Apply(Player player)
    {
        _timer = Duration;
        _bar.gameObject.SetActive(true);
    }

    public virtual void Cancel(Player player)
    {
        _bar.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private float GetInterpolatedValue()
    {
        float normalizedTime = _timer / Duration;
        return Mathf.Lerp(0, 1, normalizedTime);
    }
}