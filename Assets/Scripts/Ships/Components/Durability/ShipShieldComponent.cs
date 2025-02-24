using UnityEngine;

public class ShipShieldComponent : MonoBehaviour
{
    protected float maxShield;
    public float MaxShield
    {
        get
        {
            return maxShield;
        }
        set
        {
            if (maxShield < 0 && value >= 0)
            {
                maxShield = value;
            }
        }
    }
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
                MaxShield = value.MaxShield;
                regen = value.Regen;
            }
        }
    }
    public void OnEnable()
    {
        CurrentShield = maxShield;
    }
    /// <summary>
    /// The shield takes damage and returns the amount of 
    /// damage that got past it. If negative, the shield 
    /// hasn't been breached yet.
    /// </summary>
    /// <param name="dmgInfo">The damage ackage.</param>
    /// <returns>The amount of damage that got past the shield.</returns>
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
