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
        if (dmgInfo.DmgType == WeaponParameters.DmgType.Ballistic)
        {
            CurrentHP -= dmgInfo.Value * Numbers.HullBallisticDmgMultiplier;
        }
        else
        {
            CurrentHP -= dmgInfo.Value * Numbers.HullEnergyDmgMultiplier;
        }
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
