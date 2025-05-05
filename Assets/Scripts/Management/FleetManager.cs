using System.Collections.Generic;
using UnityEngine;

public class FleetManager : MonoBehaviour
{
    public Dictionary<ShipType, HashSet<Ship>> Ships { get; protected set; }
}
