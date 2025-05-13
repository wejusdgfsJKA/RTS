using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The squadron manages all the ships in it to execute a given order. A fleet is 
/// comprised of many fleetCommand. Squadrons can be broken and reformed at any time.
/// </summary>
[System.Serializable]
public class Squadron
{
    public int Fleet { get; protected set; }
    public float CombatPower { get; protected set; }
    /// <summary>
    /// All the ships in the squadron.
    /// </summary>
    public HashSet<Ship> Ships { get; protected set; } = new();
    /// <summary>
    /// All the subordinate fleetCommand.
    /// </summary>
    public HashSet<Squadron> Squadrons { get; protected set; } = new();
    public SquadronAI AI { get; protected set; }
    public Vector3 Position { get; protected set; }
    public Squadron(SquadronScriptable scriptable, int fleet)
    {
        Fleet = fleet;
        AI = new SquadronAI(this);
        for (int i = 0; i < scriptable.Ships.Count; i++)
        {
            var s = ShipManager.Instance.Spawn(scriptable.Ships[i], Vector3.zero);
            if (AddShip(s))
            {
                s.SymbolColor = FleetManager.Instance.Colors[fleet];
                FleetManager.Instance.Fleets[fleet].AddShip(s);
            }
        }
        for (int i = 0; i < scriptable.Squadrons.Count; i++)
        {
            Squadrons.Add(new Squadron(scriptable.Squadrons[i], fleet));
        }
    }
    public bool AddShip(Ship ship)
    {
        if (Ships.Add(ship))
        {
            ship.Squadron = this;
            CombatPower += ship.CombatPower;
            return true;
        }
        return false;
    }
    public bool RemoveShip(Ship ship)
    {
        if (Ships.Remove(ship))
        {
            CombatPower -= ship.CombatPower;
            return true;
        }
        return false;
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
        AI.Move();
        Position = Vector3.zero;
        foreach (Ship ship in Ships)
        {
            Position += ship.transform.position;
        }
        Position /= Ships.Count;
        foreach (Squadron squadron in Squadrons)
        {
            squadron.Move();
        }
    }
    public void Shoot()
    {
        AI.Shoot();
        foreach (Squadron squadron in Squadrons)
        {
            squadron.Shoot();
        }
    }
}