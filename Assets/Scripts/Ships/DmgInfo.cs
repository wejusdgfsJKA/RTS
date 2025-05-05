using UnityEngine;

/// <summary>
/// Container class for an attack.
/// </summary>
[System.Serializable]
public class DmgInfo
{
    [field: SerializeField] public Ship Source { get; set; }
    [field: SerializeField] public int Damage { get; set; }
}
