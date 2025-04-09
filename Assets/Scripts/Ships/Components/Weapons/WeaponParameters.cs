using UnityEngine;

/// <summary>
/// Front - can attack everything in front of it. <br />
/// Broadside - can attack everything to the side of it. <br />
/// All - can attack everywhere.
/// </summary>
public enum WeaponAngle { Front, Broadside, All }
/// <summary>
/// All the data regarding a weapon.
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObjects/WeaponParameters")]
public class WeaponParameters : ScriptableObject
{
    /// <summary>
    /// The damage type, see the DmgType enum for details.
    /// </summary>
    [field: SerializeField] public DmgType DamageType { get; protected set; }
    /// <summary>
    /// The angle type of the weapon, see the WeaponAngle enum for details.
    /// </summary>
    [field: SerializeField] public WeaponAngle AngleType { get; protected set; }
    /// <summary>
    /// The fire arc of the weapon, in degrees.
    /// </summary>
    [field: SerializeField] public float AngleValue { get; protected set; }
    /// <summary>
    /// How much damage the weapon does per hit.
    /// </summary>
    [field: SerializeField] public float Damage { get; protected set; }
    /// <summary>
    /// How accurate this weapon is. Higher values mean the 
    /// weapon is more accurate.
    /// </summary>
    [field: SerializeField] public float Accuracy { get; protected set; } = 1;
    /// <summary>
    /// The range of the weapon, squared.
    /// </summary>
    [field: SerializeField] public float SqrdRange { get; protected set; }
    /// <summary>
    /// How many seconds the weapon has to wait between shots.
    /// </summary>
    [field: SerializeField] public float Cooldown { get; protected set; }
}
