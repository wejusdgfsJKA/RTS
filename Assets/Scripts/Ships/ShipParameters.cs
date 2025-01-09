using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/ShipParameters")]
public class ShipParameters : ScriptableObject
{
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public float Speed { get; protected set; }
    [field: SerializeField] public float Turn { get; protected set; }
    [field: SerializeField] public float Signature { get; protected set; }
    [field: SerializeField] public float Shield { get; protected set; }
    [field: SerializeField] public float HP { get; protected set; }
    [field: SerializeField] public List<WeaponParameters> Weapons { get; protected set; }
}
