using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
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
        Transform wpns = transform.GetChild(0);
        for (int i = 0; i < wpns.childCount; i++)
        {
            Weapons.Add(wpns.GetChild(i).GetComponent<Weapon>());
        }
    }
}
