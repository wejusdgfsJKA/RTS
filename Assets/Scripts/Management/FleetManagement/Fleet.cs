using System.Collections.Generic;
using UnityEngine.Assertions;

public class Fleet
{
    public int ID { get; set; }
    public int ShipCount { get; protected set; } = 0;
    protected HashSet<Squadron> squadrons = new();
    public event System.Action<Fleet> OnFleetDestroyed;
    public Fleet(int ID, SquadronScriptable scriptable)
    {
        this.ID = ID;
        Assert.IsNull(scriptable.Ships);
        for (int i = 0; i < scriptable.Squadrons.Count; i++)
        {
            squadrons.Add(new Squadron(scriptable.Squadrons[i]));
        }
    }
    public bool AddSquadron(Squadron squadron)
    {
        return squadrons.Add(squadron);
    }
    public void Move()
    {
        foreach (var s in squadrons)
        {
            s.Move();
        }
        throw new System.NotImplementedException();
    }
    public void Shoot()
    {
        foreach (var s in squadrons)
        {
            s.Shoot();
        }
        throw new System.NotImplementedException();
    }
    public void RemoveShip(Ship ship)
    {
        ship.Squadron.RemoveShip(ship);
        ship.Squadron = null;
        ShipCount--;
        if (ShipCount <= 0)
        {
            OnFleetDestroyed?.Invoke(this);
        }
    }
}
