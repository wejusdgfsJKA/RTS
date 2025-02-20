using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/ShieldParameters")]
public class ShieldParameters : ScriptableObject
{
    [field: SerializeField] public float Signature { get; protected set; }
    [field: SerializeField] public float MaxShield { get; protected set; }
    [field: SerializeField] public float Regen { get; protected set; }
}
