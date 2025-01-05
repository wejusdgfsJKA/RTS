using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [field: SerializeField] public string Name { get; protected set; }
    [Header("Movement")]
    [field: SerializeField] public float Speed;
    [field: SerializeField] public float Turn;
    [Header("Durability")]
    [field: SerializeField] public float Signature;
    public Sensor MySensor { get; protected set; }
    public List<Weapon> Weapons { get; protected set; } = new();
    protected void Awake()
    {
        MySensor = GetComponent<Sensor>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Weapons.Add(transform.GetChild(i).GetComponent<Weapon>());
        }
    }
    public void ReceiveAttack(DmgInfo dmgInfo)
    {

    }
}
