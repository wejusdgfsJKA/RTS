using System.Collections.Generic;
using UnityEngine;

public class FleetManager : MonoBehaviour
{
    public static FleetManager Instance { get; protected set; }
    public List<Fleet> Fleets { get; protected set; } = new();
    [field: SerializeField] public List<Color> Colors { get; protected set; } = new();
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void AddFleets(List<SquadronScriptable> fleets)
    {
        for (int i = 0; i < fleets.Count; i++)
        {
            Fleet fleet = new Fleet(Fleets.Count);
            Fleets.Add(fleet);
            fleet.Populate(fleets[i]);
        }
    }
    public void HandleMovement()
    {
        for (int i = 0; i < Fleets.Count; i++)
        {
            Fleets[i].Move();
        }
    }
    public void HandleShooting()
    {
        for (int i = 0; i < Fleets.Count; i++)
        {
            Fleets[i].Shoot();
        }
    }
    public void RemoveShip(Ship ship)
    {
        Fleets[ship.Squadron.Fleet].RemoveShip(ship);
    }
}
