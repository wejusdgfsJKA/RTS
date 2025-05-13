using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A target is armed with one or multiple weapons.
/// </summary>
[System.Serializable]
public class Weapon
{
    protected DmgInfo dmgInfo;
    public Ship Source
    {
        get
        {
            return dmgInfo.Source;
        }
    }
    [field: SerializeField]
    public int Damage { get; protected set; }
    /// <summary>
    /// How far this weapon can reach.
    /// </summary>
    [field: SerializeField] public int Range { get; protected set; }
    [field: SerializeField] public int NrOfShots { get; protected set; }
    protected Transform transform;
    public Weapon(WeaponParams weaponParams, Ship ship)
    {
        Damage = weaponParams.Damage;
        Range = weaponParams.Range;
        NrOfShots = weaponParams.NrOfShots;
        dmgInfo = new DmgInfo(ship, Damage);
    }
    public void Fire(ICollection<System.Tuple<Ship, int>> targets)
    {
        int count = 0;
        foreach (var targetData in targets)
        {
            if (CanHit(targetData.Item1.transform.position))
            {
                for (int j = 0; j < targetData.Item2; j++)
                {
                    targetData.Item1.TakeDamage(dmgInfo);
                    count++;
                    if (count == NrOfShots)
                    {
                        return;
                    }
                }
            }
        }
    }
    public bool CanHit(Vector3 position)
    {
        return Vector3.Distance(transform.position, position) <= Range;
    }
}
