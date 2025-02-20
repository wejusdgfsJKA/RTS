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
    public void TakeDamage(DmgInfo dmgInfo)
    {
        CurrentHP -= dmgInfo.Value * GameManager.Instance.
            DamageModifiers[dmgInfo.Type][TargetType.Hull];
        if (CurrentHP <= 0)
        {
            Die();
        }
    }
    protected void Die()
    {
        transform.root.gameObject.SetActive(false);
    }
}
