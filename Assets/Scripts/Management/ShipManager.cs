using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public static ShipManager Instance { get; protected set; }
    protected Dictionary<int, Queue<Ship>> pool = new();
    protected Dictionary<int, Ship> roster = new();
    [SerializeField] protected List<ShipParams> ships = new();
    protected void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        for (int i = 0; i < ships.Count; i++)
        {
            roster.Add(ships[i].ID, ships[i].Prefab);
        }
    }
    public Ship Spawn(int ID, Vector3 position)
    {
        Ship ship = GetFromPool(ID);
        if (ship != null)
        {
            //we have an inactive ship we can reactivate
            ship.transform.position = position;
            ship.gameObject.SetActive(true);
        }
        else
        {
            //we need to instantiate a new ship
            ship = Instantiate(roster[ID], position, Quaternion.identity);
        }
        return ship;
    }
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
