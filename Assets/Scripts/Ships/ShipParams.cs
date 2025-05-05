using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ShipParameters")]
public class ShipParams : ScriptableObject
{
    [field: SerializeField] public int ID { get; protected set; }
    [field: SerializeField] public ShipType ShipType { get; protected set; }
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public int HP { get; protected set; } = 1;
    [field: SerializeField] public int Speed { get; protected set; } = 1;
    [field: SerializeField] public Ship Prefab { get; protected set; }
    [field: SerializeField] public List<Weapon> Weapons { get; protected set; }
}
