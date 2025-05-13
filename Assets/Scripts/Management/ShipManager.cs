using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public static ShipManager Instance { get; protected set; }
    /// <summary>
    /// The current pool of disabled ships.
    /// </summary>
    protected Dictionary<int, Queue<Ship>> pool = new();
    protected void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    /// <summary>
    /// Spawn a ship with a given ID. Will try to get one from a pool, if not will
    /// instantiate a new one.
    /// </summary>
    /// <param name="ID">The ID which will be used to search for the ship.</param>
    /// <param name="position">Where we want the ship to be spawned.</param>
    /// <returns>Null if the ID was not found in the roster, otherwise will 
    /// return the ship.</returns>
    public Ship Spawn(ShipParams scriptable, Vector3 position)
    {
        Ship ship = GetFromPool(scriptable.ID);
        if (ship != null)
        {
            //we have an inactive ship we can reactivate
            ship.transform.position = position;
            ship.gameObject.SetActive(true);
            return ship;
        }
        //we need to instantiate a new ship
        ship = Instantiate(scriptable.Prefab, position, Quaternion.identity);
        return ship;
    }
    /// <summary>
    /// Get a ship from the pool.
    /// </summary>
    /// <param name="ID">The ID of the ship.</param>
    /// <returns>A disabled ship if found, null otherwise.</returns>
    protected Ship GetFromPool(int ID)
    {
        Queue<Ship> q;
        if (pool.TryGetValue(ID, out q))
        {
            Ship ship;
            if (q.TryDequeue(out ship))
            {
                return ship;
            }
        }
        return null;
    }
    /// <summary>
    /// Add a ship to its coresponding pool (will create a new 
    /// pool if none is found).
    /// </summary>
    /// <param name="ship">The ship in question.</param>
    public void AddToPool(Ship ship)
    {
        Queue<Ship> q;
        if (pool.TryGetValue(ship.ID, out q))
        {
            q.Enqueue(ship);
        }
        else
        {
            pool.Add(ship.ID, new(new[] { ship }));
        }
    }
}
