using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponParameters")]
public class WeaponParams : ScriptableObject
{
    [field: SerializeField] public int Damage { get; protected set; }
    [field: SerializeField] public int Range { get; protected set; }
    [field: SerializeField] public int NrOfShots { get; protected set; }
}
