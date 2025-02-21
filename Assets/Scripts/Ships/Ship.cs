using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipHPComponent))]
[RequireComponent(typeof(ShipShieldComponent))]
public class Ship : MonoBehaviour
{
    [field: SerializeField] public ShipParameters Parameters { get; protected set; }
    public List<Weapon> Weapons { get; protected set; } = new();
    protected ShipHPComponent hpComponent;
    protected ShipShieldComponent shieldComponent;
    public float CurrentHP
    {
        get
        {
            return hpComponent.CurrentHP;
        }
    }
    public float CurrentShield
    {
        get
        {
            return shieldComponent.CurrentShield;
        }
    }
    protected void Awake()
    {
        hpComponent = GetComponent<ShipHPComponent>();
        hpComponent.SetMaxHP(Parameters.HP);

        shieldComponent = GetComponent<ShipShieldComponent>();

        shieldComponent.Parameters = Parameters.ShieldParams;

        var wpns = transform.GetChild(0);//cache the weapons holder
        for (int i = 0; i < wpns.childCount; i++)
        {
            var wpn = wpns.GetChild(i).GetComponent<Weapon>();
            wpn.Parameters = Parameters.WeaponParams[i];
            Weapons.Add(wpn);
        }
    }
    protected void OnEnable()
    {
        EntityManager.Instance.RegisterShip(this);
    }
    /// <summary>
    /// Receive an attack from a source of damage.
    /// </summary>
    /// <param name="dmgInfo">Damage package.</param>
    public void ReceiveAttack(DmgInfo dmgInfo)
    {
        //the breach variable represents how much damage got past the shields
        float breach = shieldComponent.TakeDamage(dmgInfo);
        if (breach > 0)
        {
            hpComponent.TakeDamage(new DmgInfo(dmgInfo.Owner, breach, dmgInfo.Type));
        }
    }
}
