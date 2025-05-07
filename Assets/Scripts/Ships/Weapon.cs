using UnityEngine;

/// <summary>
/// A target is armed with one or multiple weapons.
/// </summary>
[System.Serializable]
public class Weapon
{
    protected DmgInfo dmgInfo = new();
    public Ship Source
    {
        set
        {
            dmgInfo.Source = value;
            dmgInfo.Damage = Damage;
            transform = value.transform;
        }
    }
    [field: SerializeField]
    public int Damage { get; set; }
    /// <summary>
    /// How far this weapon can reach.
    /// </summary>
    [field: SerializeField] public int Range { get; protected set; }
    [field: SerializeField] public float Cooldown { get; protected set; }
    protected float timeLastFired;
    protected Transform transform;
    public bool Fire(Ship target)
    {
        if (CanFire() && CanHit(target.transform.position))
        {
            target.TakeDamage(dmgInfo);
            timeLastFired = Time.time;
            return true;
        }
        return false;
    }
    public bool CanHit(Vector3 position)
    {
        return Vector3.Distance(transform.position, position) <= Range;
    }
    public bool CanFire()
    {
        return Time.time - timeLastFired >= Cooldown;
    }
}
