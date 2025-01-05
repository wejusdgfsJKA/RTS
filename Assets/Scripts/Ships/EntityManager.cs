using System.Collections.Generic;
using UnityEngine;

//this script will handle taking damage etc.
public class EntityManager : MonoBehaviour
{
    public static EntityManager Instance { get; protected set; }
    public Dictionary<string, Ship> Roster { get; protected set; }
    public Dictionary<Transform, Ship> Ships { get; protected set; }
    protected Dictionary<string, Queue<Ship>> pool;
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    protected void OnEnable()
    {
        Roster = new();
        Ships = new();
        pool = new();
    }
    public void AddToRoster(Ship ship)
    {
        //add an entity to the roster
        try
        {
            Roster.Add(ship.Name, ship);
            //Debug.Log("Added " + entityData.Name + " to roster.");
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
        try
        {
            pool.Add(ship.Name, new Queue<Ship>());
            //Debug.Log("Added " + entityData.Name + " to roster.");
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    public void RegisterShip(Ship ship)
    {
        Ships.Add(ship.transform, ship);
    }
    public void AddToPool(string ship)
    {
        pool.Add(ship, new Queue<Ship>());
    }
    public Ship GetFromPool(string ship)
    {
        if (pool[ship].Count > 0)
        {
            return pool[ship].Dequeue();
        }
        return null;
    }
    public void Dead(Ship ship)
    {
        //this ship just got destroyed
        try
        {
            pool[ship.Name].Enqueue(ship);
        }
        catch (KeyNotFoundException)
        {
            pool.Add(ship.Name, new Queue<Ship>());
            pool[ship.Name].Enqueue(ship);
        }
    }
    public void SendAttack(Transform ship, DmgInfo dmgInfo)
    {
        //send the ship the damage package
        try
        {
            Ships[ship].ReceiveAttack(dmgInfo);
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }
}
