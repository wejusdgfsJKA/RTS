using System.Collections.Generic;
using UnityEngine.Assertions;

public class Fleet
{
    public int ID { get; set; }
    public int ShipCount { get; protected set; } = 0;
    protected Squadron fleetCommand;
    public HashSet<Ship> Ships { get; protected set; } = new();
    public List<Ship> Targets { get; protected set; } = new();
    public event System.Action<Fleet> OnFleetDestroyed;
    public Fleet(int ID)
    {
        this.ID = ID;
    }
    public void Populate(SquadronScriptable scriptable)
    {
        Assert.AreEqual(scriptable.Ships.Count, 0);
        Assert.AreEqual<int>(1, scriptable.Squadrons.Count);
        ShipCount = ComputeShipCount(scriptable);
        fleetCommand = new Squadron(scriptable.Squadrons[0], ID);
    }
    public int ComputeShipCount(SquadronScriptable scriptable)
    {
        int s = scriptable.Ships.Count;
        for (int i = 0; i < scriptable.Squadrons.Count; i++)
        {
            s += ComputeShipCount(scriptable.Squadrons[i]);
        }
        return s;
    }
    public void Move()
    {
        Targets.Clear();
        for (int i = 0; i < FleetManager.Instance.Fleets.Count; i++)
        {
            if (i == ID)
            {
                continue;
            }
            Targets.AddRange(FleetManager.Instance.Fleets[i].Ships);
        }
        fleetCommand.Move();
    }
    public void Shoot()
    {
        fleetCommand.Shoot();
    }
    public bool AddShip(Ship ship)
    {
        if (Ships.Add(ship))
        {
            ShipCount++;
            return true;
        }
        return false;
    }
    public void RemoveShip(Ship ship)
    {
        ship.Squadron.RemoveShip(ship);
        ship.Squadron = null;
        if (Ships.Remove(ship))
        {
            ShipCount--;
            if (ShipCount <= 0)
            {
                OnFleetDestroyed?.Invoke(this);
            }
        }
    }
}
