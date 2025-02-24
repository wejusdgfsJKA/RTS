using UnityEngine;

public class ShipHPComponent : MonoBehaviour
{
    public float MaxHP { get; protected set; } = -1;
    public float CurrentHP { get; protected set; }
    protected void OnEnable()
    {
        CurrentHP = MaxHP;
    }
    public void SetMaxHP(float value)
    {
        if (MaxHP < 0)
        {
            MaxHP = value;
        }
    }
    /// <summary>
    /// Take damage. If reduced to 0 or below HP, call the Die method.
    /// </summary>
    /// <param name="dmgInfo">The damage package.</param>
    public void TakeDamage(DmgInfo dmgInfo)
    {
        CurrentHP -= dmgInfo.Value * GameManager.Instance.
            DamageModifiers[dmgInfo.Type][TargetType.Hull];
        if (CurrentHP <= 0)
        {
            Die();
        }
    }
    /// <summary>
    /// Fires when the ship is destroyed.
    /// </summary>
    protected void Die()
    {
        transform.root.gameObject.SetActive(false);
    }
}
