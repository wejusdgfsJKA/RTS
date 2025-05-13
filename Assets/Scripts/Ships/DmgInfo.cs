using UnityEngine;

/// <summary>
/// Container class for an attack.
/// </summary>
[System.Serializable]
public class DmgInfo
{
    [field: SerializeField] public Ship Source { get; protected set; }
    [field: SerializeField] public int Damage { get; protected set; }
    public DmgInfo(Ship source, int damage)
    {
        Source = source;
        Damage = damage;
    }
}
