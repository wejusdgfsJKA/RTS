using System.Collections.Generic;
using UnityEngine;

//this script will handle taking damage etc.
public class EntityManager : MonoBehaviour
{
    /// <summary>
    /// The instance of the manager, only one can exist at any given time.
    /// </summary>
    public static EntityManager Instance { get; protected set; }
    /// <summary>
    /// The roster of ships that can be spawned.
    /// </summary>
    protected Dictionary<int, Ship> roster = new();
    /// <summary>
    /// The list of active ships.
    /// </summary>
    protected Dictionary<Transform, Ship> ships = new();
    /// <summary>
    /// The pool of available ships. The key is each ship's internal ID.
    /// </summary>
    protected Dictionary<int, Queue<Ship>> pool = new();
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    /// <summary>
    /// Adds a new ship to the manager's roster of possible ships to spawn.
    /// </summary>
    /// <param name="ship">The ship to be added.</param>
    /// <returns>True if the ship was added succesfully.</returns>
    public bool AddToRoster(Ship ship)
    {
        if (roster.TryAdd(ship.Parameters.ID, ship))
        {
            pool.Add(ship.Parameters.ID, new Queue<Ship>());
            return true;
        }
        return false;
    }
    /// <summary>
    /// Get a ship from the roster.
    /// </summary>
    /// <param name="shipID">The internal ID of the ship.</param>
    /// <returns>The ship if it exists in the roster, or null otherwise.</returns>
    public Ship GetFromRoster(int shipID)
    {
        Ship ship;
        if (roster.TryGetValue(shipID, out ship))
        {
            return ship;
        }
        return null;
    }
    /// <summary>
    /// Adds the ship to the manager's list of active ships, so it can be detected and receive attacks.
    /// </summary>
    /// <param name="ship">The ship to be added.</param>
    public void RegisterShip(Ship ship)
    {
        ships.Add(ship.transform, ship);
    }
    /// <summary>
    /// Get a ship from the pool of existing ships.
    /// </summary>
    /// <param name="shipID">Internal ID of the ship.</param>
    /// <param name="createPool">If true, create a new pool if no existing pool is found.</param>
    /// <returns>A Ship instance if a valid one was found, null if the respective pool was empty or didn't exist.</returns>
    public Ship GetFromPool(int shipID, bool createPool)
    {
        Queue<Ship> queue;
        if (pool.TryGetValue(shipID, out queue))
        {
            if (queue.Count > 0)
            {
                return queue.Dequeue();
            }
            return null;
        }
        if (createPool)
        {
            pool.Add(shipID, new Queue<Ship>());
        }
        return null;
    }
    /// <summary>
    /// The ship has been destroyed.
    /// </summary>
    /// <param name="ship">The Ship instance that was destroyed.</param>
    public void Dead(Ship ship)
    {
        if (ships.Remove(ship.transform))
        {
            pool[ship.Parameters.ID].Enqueue(ship);
        }
    }
    /// <summary>
    /// Send a target the damage package.
    /// </summary>
    /// <param name="target"> The object being attacked. </param>
    /// <param name="dmgInfo"> The damage package. </param>
    /// <returns></returns>
    public bool SendAttack(Transform target, DmgInfo dmgInfo)
    {
        //send the ship the damage package
        Ship ship;
        if (ships.TryGetValue(target, out ship))
        {
            ship.ReceiveAttack(dmgInfo);
            return true;
        }
        return false;
    }
}
