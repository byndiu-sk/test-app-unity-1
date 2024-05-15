using UnityEngine;

public abstract class TemporaryBoostItem : BoostItem
{
    [SerializeField] private float _duration;
    [SerializeField] protected Bar _bar;

    private float _timer = 0f;
    private bool _isActive = false;
    
    public float Duration => _duration;

    public bool IsActive => _isActive;
    
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
        _isActive = true;
        _timer = Duration;
        _bar.gameObject.SetActive(true);
    }

    public virtual void Cancel(Player player)
    {
        _isActive = false;
        _bar.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private float GetInterpolatedValue()
    {
        float normalizedTime = _timer / Duration;
        return Mathf.Lerp(0, 1, normalizedTime);
    }
}