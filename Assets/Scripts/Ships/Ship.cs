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
    public float Evasion
    {
        get
        {
            return Parameters.Evasion;
        }
    }
    public float MaxHP
    {
        get
        {
            return hpComponent.MaxHP;
        }
    }
    public float CurrentHP
    {
        get
        {
            return hpComponent.CurrentHP;
        }
    }
    public float MaxShield
    {
        get
        {
            return shieldComponent.MaxShield;
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
    /// Receive a damage package.
    /// </summary>
    /// <param name="dmgInfo">The damage package.</param>
    /// <returns>True if the source of damage did not miss.</returns>
    public bool ReceiveAttack(DmgInfo dmgInfo)
    {
        var chanceToHit = dmgInfo.Accuracy - Evasion;
        if (chanceToHit <= 0)
        {
            //the hit is guaranteed to miss.
            return false;
        }
        if (chanceToHit < 1)
        {
            //the hit has a chance to miss
            var a = Random.Range(0, 1);
            if (a > chanceToHit)
            {
                //the hit missed
                return false;
            }
        }
        //the breach variable represents how much damage got past the shields
        float breach = shieldComponent.TakeDamage(dmgInfo);
        if (breach > 0)
        {
            hpComponent.TakeDamage(new DmgInfo(dmgInfo.Owner, breach, dmgInfo.Type, dmgInfo.Accuracy));
        }
        return true;
    }
    protected void OnDisable()
    {
        EntityManager.Instance.Dead(this);
    }
}
