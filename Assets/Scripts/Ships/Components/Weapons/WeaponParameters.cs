using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/WeaponParameters")]
public class WeaponParameters : ScriptableObject
{
    public enum Angle { Front, Broadside, All }
    [field: SerializeField] public float Signature { get; protected set; }
    [field: SerializeField] public DmgType DamageType { get; protected set; }
    [field: SerializeField] public Angle AngleType { get; protected set; }
    [field: SerializeField] public float AngleValue { get; protected set; }
    [field: SerializeField] public float Damage { get; protected set; }
    [field: SerializeField] public float SqrdRange { get; protected set; }
    [field: SerializeField] public int Attacks { get; protected set; }//this represents the number of attacks the weapon can make
}
