using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The entity comprising a squadron.
/// </summary>
[System.Serializable]
public class Ship : MonoBehaviour
{
    [SerializeField] protected ShipParams parameters;
    public int ID
    {
        get
        {
            return parameters.ID;
        }
    }
    /// <summary>
    /// The squadron this ship is a part of.
    /// </summary>
    public Squadron Squadron { get; set; }
    public ShipType ShipType
    {
        get
        {
            return parameters.ShipType;
        }
    }
    /// <summary>
    /// How fast the ship can move.
    /// </summary>
    public int Speed
    {
        get
        {
            return parameters.Speed;
        }
    }
    public List<Weapon> Weapons
    {
        get
        {
            return parameters.Weapons;
        }
    }
    /// <summary>
    /// How much HP the ship currently has.
    /// </summary>
    public int CurrentHP { get; protected set; }
    protected void Awake()
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].Source = this;
        }
    }
    protected void OnEnable()
    {
        CurrentHP = parameters.HP;
    }
    public void MoveToPoint(Vector3 point)
    {
        if (Vector3.Distance(point, transform.position) < Speed)
        {
            transform.position = point;
        }
        else
        {
            transform.position += (point - transform.position) * Speed;
        }
    }
    /// <summary>
    /// Receive damage.
    /// </summary>
    /// <param name="dmgInfo">The damage package.</param>
    public void TakeDamage(DmgInfo dmgInfo)
    {
        CurrentHP -= dmgInfo.Damage;
        if (CurrentHP <= 0)
        {
            Die();
        }
    }
    /// <summary>
    /// Fires when the ship's HP reaches 0.
    /// </summary>
    protected virtual void Die()
    {
        GameManager.AddShipToCleanupQueue(this);
    }
}
