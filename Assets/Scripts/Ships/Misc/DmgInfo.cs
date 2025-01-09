using UnityEngine;
public class DmgInfo
{
    public Transform Owner { get; set; }
    public float Value { get; set; }
    public WeaponParameters.DmgType DmgType { get; set; }
    public DmgInfo(Transform owner, float value, WeaponParameters.DmgType dmgType)
    {
        Owner = owner;
        Value = value;
        DmgType = dmgType;
    }
}
