public class ShipShieldComponent : ShipComponent
{
    public float MaxShield { get; protected set; } = -1;
    public float CurrentShield { get; protected set; }
    protected ShipHPComponent hpComponent;
    protected void Awake()
    {
        hpComponent = GetComponent<ShipHPComponent>();
    }
    protected void OnEnable()
    {
        CurrentShield = MaxShield;
    }
    public void SetMaxShield(float value)
    {
        if (MaxShield < 0)
        {
            MaxShield = value;
        }
    }
    public void TakeDamage(DmgInfo dmgInfo)
    {
        if (dmgInfo.DmgType == WeaponParameters.DmgType.Ballistic)
        {
            CurrentShield -= dmgInfo.Value * Numbers.ShieldBallisticDmgMultiplier;
        }
        else
        {
            CurrentShield -= dmgInfo.Value * Numbers.ShieldEnergyDmgMultiplier;
        }
        if (CurrentShield < 0)
        {
            DmgInfo newDmgInfo = new DmgInfo(dmgInfo.Owner, -CurrentShield, dmgInfo.DmgType);
            hpComponent.TakeDamage(newDmgInfo);
            CurrentShield = 0;
        }
    }
    protected void Die()
    {
        transform.root.gameObject.SetActive(false);
    }
}
