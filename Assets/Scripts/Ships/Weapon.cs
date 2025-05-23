using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship is armed with one or multiple weapons.
/// </summary>
[System.Serializable]
public class Weapon
{
    protected DmgInfo dmgInfo;
    /// <summary>
    /// The ship the weapon is attached to.
    /// </summary>
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
    public int Range { get; protected set; }
    /// <summary>
    /// The maximum number of shots we can fire per salvo.
    /// </summary>
    public int NrOfShots { get; protected set; }
    public int Cooldown { get; protected set; }
    protected Transform transform;
    /// <summary>
    /// On what turn did we fire last time.
    /// </summary>
    public int LastTurnFired { get; protected set; } = 0;
    /// <summary>
    /// True if the weapon is off cooldown.
    /// </summary>
    public bool ReadyToFire
    {
        get
        {
            return GameManager.Instance.CurrentTurn - LastTurnFired >= Cooldown;
        }
    }
    public Weapon(WeaponParams weaponParams, Ship ship)
    {
        Damage = weaponParams.Damage;
        Range = weaponParams.Range;
        NrOfShots = weaponParams.NrOfShots;
        Cooldown = weaponParams.Cooldown;
        dmgInfo = new DmgInfo(ship, Damage);
    }
    /// <summary>
    /// Shoot a series of targets a given number of times.
    /// </summary>
    /// <param name="targets">The targets to fire at and how many shots to fire at each.</param>
    /// <returns>True if we were able to fire.</returns>
    public bool Fire(ICollection<System.Tuple<Ship, int>> targets)
    {
        if (ReadyToFire)
        {
            LastTurnFired = GameManager.Instance.CurrentTurn;
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
                            //We have fired the maximum amount of shots per salvo.
                            return true;
                        }
                    }
                }
            }
            return true;
        }
        return false;
    }
    /// <summary>
    /// Range check.
    /// </summary>
    /// <param name="position">The position we want to hit.</param>
    /// <returns>True if we can hit said position.</returns>
    public bool CanHit(Vector3 position)
    {
        return Vector3.Distance(transform.position, position) <= Range;
    }
}
