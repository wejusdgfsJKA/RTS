using UnityEngine;
/// <summary>
/// Damage package.
/// </summary>
public class DmgInfo
{
    /// <summary>
    /// The entity who dealt the damage.
    /// </summary>
    public Transform Owner { get; protected set; }
    /// <summary>
    /// How much damage was dealt.
    /// </summary>
    public float Value { get; set; }
    /// <summary>
    /// The type of damage that was dealt.
    /// </summary>
    public DmgType Type { get; protected set; }
    /// <summary>
    /// How accurate this hit is.
    /// </summary>
    public float Accuracy { get; protected set; }
    public DmgInfo(Transform owner, float value, DmgType dmgType, float accuracy)
    {
        Owner = owner;
        Value = value;
        Type = dmgType;
        Accuracy = accuracy;
    }
}
