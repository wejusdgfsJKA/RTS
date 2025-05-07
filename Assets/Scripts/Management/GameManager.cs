using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; protected set; }
    /// <summary>
    /// What is the duration between turns.
    /// </summary>
    [SerializeField] protected float turnCooldown = 1;
    [SerializeField] protected List<SquadronScriptable> fleets = new();
    protected static Queue<Ship> cleanupQueue = new();
    protected Coroutine coroutine;
    protected WaitForSeconds wait;
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        wait = new WaitForSeconds(turnCooldown);
    }
    protected void OnEnable()
    {
        for (int i = 0; i < fleets.Count; i++)
        {
            FleetManager.Instance.AddFleet(fleets[i]);
        }
        coroutine = StartCoroutine(UpdateLoop());
    }
    protected void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
    protected IEnumerator UpdateLoop()
    {
        while (true)
        {
            yield return wait;
            HandleMovement();
            yield return wait;
            HandleShooting();
            //handle missiles separately?
            PerformCleanup();
        }
    }
    protected void HandleMovement()
    {
        FleetManager.Instance.HandleMovement();
    }
    protected void HandleShooting()
    {
        FleetManager.Instance.HandleShooting();
    }
    protected void PerformCleanup()
    {
        while (cleanupQueue.Count > 0)
        {
            var ship = cleanupQueue.Dequeue();
            ship.gameObject.SetActive(false);
            ShipManager.Instance.AddToPool(ship);
            // WIP, we also need to remove the ships from their fleets,
            // we'll figure that one out later
            FleetManager.Instance.RemoveShip(ship);
        }
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// Adds this ship to the queue of ships which need to be removed at the end
    /// of every "turn". Might try to parallelize this in the future.
    /// </summary>
    /// <param name="ship">The ship that needs to be removed.</param>
    public static void AddShipToCleanupQueue(Ship ship)
    {
        cleanupQueue.Enqueue(ship);
    }
}
