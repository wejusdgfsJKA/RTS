using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    /// <summary>
    /// Spawn a new ship.
    /// </summary>
    /// <param name="shipID">Internal ID of the ship.</param>
    /// <param name="position">Desired position.</param>
    /// <param name="rotation">Desired rotation.</param>
    public void Spawn(int shipID, Vector3 position, Quaternion rotation)
    {
        Ship ship = EntityManager.Instance.GetFromPool(shipID, true);
        if (ship != null)
        {
            //we have inactive entities we can reactivate
            ship.transform.position = position;
            ship.transform.rotation = rotation;
            ship.gameObject.SetActive(true);
            return;
        }
        else
        {
            //the pool was empty, so we must instantiate a new prefab
            Ship newShip = Instantiate(EntityManager.Instance.GetFromRoster(shipID),
                position, rotation);
            newShip.gameObject.SetActive(true);
        }
    }
}
