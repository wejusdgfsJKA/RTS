using System.Collections.Generic;
using UnityEngine;

public class FleetManager : MonoBehaviour
{
    public static FleetManager Instance { get; protected set; }
    protected List<Fleet> fleets = new();
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public Fleet AddFleet(SquadronScriptable scriptable)
    {
        Fleet fleet = new Fleet(fleets.Count, scriptable);
        fleets.Add(fleet);
        return fleet;
    }
    public void HandleMovement()
    {
        for (int i = 0; i < fleets.Count; i++)
        {
            fleets[i].Move();
        }
    }
    public void HandleShooting()
    {
        for (int i = 0; i < fleets.Count; i++)
        {
            fleets[i].Shoot();
        }
    }
    public void RemoveShip(Ship ship)
    {
        fleets[ship.Squadron.Fleet].RemoveShip(ship);
    }
}
