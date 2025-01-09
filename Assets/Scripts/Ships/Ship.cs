using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [field: SerializeField] public ShipParameters Parameters { get; protected set; }
    public Sensor MySensor { get; protected set; }
    public List<Weapon> Weapons { get; protected set; } = new();
    public Transform Symbol { get; protected set; }
    protected ShipShieldComponent shieldComponent;
    protected ShipHPComponent hpComponent;
    protected void Awake()
    {
        hpComponent = GetComponent<ShipHPComponent>();
        shieldComponent = GetComponent<ShipShieldComponent>();
        Symbol = transform.GetChild(1);
        MySensor = GetComponent<Sensor>();
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Weapons.Add(transform.GetChild(0).GetChild(i).GetComponent<Weapon>());
            Weapons[i].Parameters = Parameters.Weapons[i];
        }
        shieldComponent.SetMaxShield(Parameters.Shield);
        hpComponent.SetMaxHP(Parameters.HP);
    }
    public void ReceiveAttack(DmgInfo dmgInfo)
    {
        shieldComponent.TakeDamage(dmgInfo);
    }
}
