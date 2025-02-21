using UnityEngine;

public class ShipShieldComponent : MonoBehaviour
{
    protected float maxShield;
    protected float currentShield;
    public float CurrentShield
    {
        get
        {
            return currentShield;
        }
        protected set
        {
            if (value <= maxShield && value >= 0)
            {
                currentShield = value;
            }
        }
    }
    protected float regen;
    public ShieldParameters Parameters
    {
        set
        {
            if (value != null)
            {
                maxShield = value.MaxShield;
                regen = value.Regen;
            }
        }
    }
    public void OnEnable()
    {
        CurrentShield = maxShield;
    }
    public float TakeDamage(DmgInfo dmgInfo)
    {
        //breach represents how much damage got past the shields
        var breach = dmgInfo.Value - CurrentShield / GameManager.Instance.
            DamageModifiers[dmgInfo.Type][TargetType.Shield];
        if (breach >= 0)
        {
            CurrentShield = 0;
        }
        else
        {
            CurrentShield -= dmgInfo.Value * GameManager.Instance.
                DamageModifiers[dmgInfo.Type][TargetType.Shield];
        }
        return breach;
    }
    protected void FixedUpdate()
    {
        CurrentShield += regen;
    }
}
