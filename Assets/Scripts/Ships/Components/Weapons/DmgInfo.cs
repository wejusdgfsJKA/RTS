using UnityEngine;
public class DmgInfo
{
    public Transform Owner { get; protected set; }
    public float Value { get; set; }
    public DmgType Type { get; protected set; }
    public DmgInfo(Transform owner, float value, DmgType dmgType)
    {
        Owner = owner;
        Value = value;
        Type = dmgType;
    }
}
