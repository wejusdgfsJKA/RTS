using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A scriptable object which contains all the data about a ship.
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObjects/ShipParameters")]
public class ShipParameters : ScriptableObject
{
    /// <summary>
    /// Internal ID of the ship.
    /// </summary>
    [field: SerializeField] public int ID { get; protected set; }
    [field: SerializeField] public float Speed { get; protected set; }
    /// <summary>
    /// How fast can the ship turn.
    /// </summary>
    [field: SerializeField] public float Turn { get; protected set; }
    /// <summary>
    /// How difficult the ship is to target. Default is 0. 
    /// Higher values mean the ship is more difficult to hit.
    /// </summary>
    [field: SerializeField] public float Evasion { get; protected set; }
    [field: SerializeField] public float HP { get; protected set; }
    [field: SerializeField] public ShieldParameters ShieldParams { get; protected set; }
    /// <summary>
    /// The parameters of all of the ship's weapons.
    /// </summary>
    [field: SerializeField] public List<WeaponParameters> WeaponParams { get; protected set; }
    [field: SerializeField] public float SensorRange { get; protected set; }
}
