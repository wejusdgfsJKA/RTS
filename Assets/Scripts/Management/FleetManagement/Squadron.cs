using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The squadron manages all the ships in it to execute a given order. A fleet is 
/// comprised of many squadrons. Squadrons can be broken and reformed at any time.
/// </summary>
[System.Serializable]
public class Squadron
{
    public int Fleet { get; set; }
    /// <summary>
    /// All the ships in the squadron.
    /// </summary>
    public HashSet<Ship> Ships { get; protected set; }
    /// <summary>
    /// All the subordinate squadrons.
    /// </summary>
    public HashSet<Squadron> Squadrons { get; protected set; }
    public Squadron(SquadronScriptable scriptable)
    {
        for (int i = 0; i < scriptable.Ships.Count; i++)
        {
            var s = ShipManager.Instance.Spawn(scriptable.Ships[i].ID, Vector3.zero);
            Ships.Add(s);
        }
        for (int i = 0; i < scriptable.Squadrons.Count; i++)
        {
            Squadrons.Add(new Squadron(scriptable.Squadrons[i]));
        }
    }
    public bool AddShip(Ship ship)
    {
        if (Ships.Add(ship))
        {
            ship.Squadron = this;
            return true;
        }
        return false;
    }
    public void RemoveShip(Ship ship)
    {
        Ships.Remove(ship);
    }
    public bool AddSquadron(Squadron squadron)
    {
        return Squadrons.Add(squadron);
    }
    public void RemoveSquadron(Squadron squadron)
    {
        Squadrons.Remove(squadron);
    }
    public void Move()
    {
        throw new System.NotImplementedException();
    }
    public void Shoot()
    {
        throw new System.NotImplementedException();
    }
}

[CreateAssetMenu(menuName = "ScriptableObjects/Squadron")]
public class SquadronScriptable : ScriptableObject
{
    [field: SerializeField] public List<ShipParams> Ships { get; protected set; } = new();
    [field: SerializeField] public List<SquadronScriptable> Squadrons { get; protected set; } = new();
}