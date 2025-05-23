using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponParameters")]
public class WeaponParams : ScriptableObject
{
    [field: SerializeField] public int Damage { get; protected set; }
    [field: SerializeField] public int Range { get; protected set; }
    [field: SerializeField] public int NrOfShots { get; protected set; }
    /// <summary>
    /// How many turns does this weapon need to wait before firing.
    /// </summary>
    [field: SerializeField] public int Cooldown { get; protected set; }
}
