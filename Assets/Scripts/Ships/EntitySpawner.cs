using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public void Spawn(string shipName, Vector3 position, Quaternion rotation)
    {
        try
        {
            Ship ship = EntityManager.Instance.GetFromPool(shipName);
            if (ship != null)
            {
                //we have inactive entities we can reactivate
                ship.transform.position = position;
                ship.transform.rotation = rotation;
                ship.gameObject.SetActive(true);
            }
            else
            {
                //the pool was empty
                CreateNew(shipName, position, rotation);
            }
        }
        catch (KeyNotFoundException)
        {
            //we had no available pool
            EntityManager.Instance.AddToPool(shipName);
            CreateNew(shipName, position, rotation);
        }
    }
    protected void CreateNew(string shipName, Vector3 position, Quaternion rotation)
    {
        try
        {
            //we instantiate a new prefab
            Ship ship = Instantiate(EntityManager.Instance.
                Roster[shipName], position, rotation);
            //register the script in the transform dictionary, to allow damage to
            //pass to it via its transform
            EntityManager.Instance.RegisterShip(ship);
            ship.gameObject.SetActive(true);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
