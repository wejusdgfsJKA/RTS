using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/ShieldParameters")]
public class ShieldParameters : ScriptableObject
{
    [field: SerializeField] public float MaxShield { get; protected set; }
    /// <summary>
    /// The shield regenerates by this much per FixedUpdate, never exceeds MaxShield.
    /// </summary>
    [field: SerializeField] public float Regen { get; protected set; }
}
