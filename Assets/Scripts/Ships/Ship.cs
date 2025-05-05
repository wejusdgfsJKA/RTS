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
    public Squadron ParentSquadron { get; set; }
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
    protected void OnDisable()
    {
        ParentSquadron.RemoveShip(this);
        ParentSquadron = null;
        ShipManager.Instance?.AddToPool(this);
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
    /// Fires when the ship is destroyed. Deactivates the ship GameObject.
    /// </summary>
    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
