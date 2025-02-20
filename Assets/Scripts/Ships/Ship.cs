using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipHPComponent))]
[RequireComponent(typeof(ShipShieldComponent))]
public class Ship : MonoBehaviour
{
    protected float signature;
    public float Signature
    {
        get
        {
            return signature;
        }
        set
        {
            if (value >= 0)
            {
                signature = value;
            }
        }
    }
    [field: SerializeField] public ShipParameters Parameters { get; protected set; }
    public Sensor MySensor { get; protected set; }
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
        Signature = Parameters.Signature;

        hpComponent = GetComponent<ShipHPComponent>();
        hpComponent.SetMaxHP(Parameters.HP);

        shieldComponent = GetComponent<ShipShieldComponent>();

        shieldComponent.Parameters = Parameters.ShieldParams;

        var wpns = transform.GetChild(0);//cache the weapons holder
        for (int i = 0; i < wpns.childCount; i++)
        {
            var wpn = wpns.GetChild(i).GetComponent<Weapon>();
            wpn.Parameters = Parameters.Weapons[i];
            Weapons.Add(wpn);
        }

        MySensor = GetComponent<Sensor>();
        MySensor.Parameters = Parameters.SensorParams;
    }
    protected void OnEnable()
    {
        shieldComponent.Reset();
    }
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
