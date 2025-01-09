using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/WeaponParameters")]
public class WeaponParameters : ScriptableObject
{
    public enum DmgType { Ballistic, Energy }
    public enum Angle { Front, Broadside, All }
    [field: SerializeField] public DmgType DamageType { get; protected set; }
    [field: SerializeField] public Angle AngleType { get; protected set; }
    [field: SerializeField] public float AngleValue { get; protected set; }
    [field: SerializeField] public float Damage { get; protected set; }
}
