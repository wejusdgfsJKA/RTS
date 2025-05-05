using System.Collections.Generic;

/// <summary>
/// The squadron manages all the ships in it to execute a given order. A fleet is 
/// comprised of many squadrons. Squadrons can be broken and reformed at any time.
/// </summary>
[System.Serializable]
public class Squadron
{
    /// <summary>
    /// All the ships in the squadron.
    /// </summary>
    public HashSet<Ship> Ships { get; protected set; }
    /// <summary>
    /// All the subordinate squadrons.
    /// </summary>
    public HashSet<Squadron> Squadrons { get; protected set; }
    public Orders Order { get; protected set; }
    public bool AddShip(Ship ship)
    {
        return Ships.Add(ship);
    }
    public void RemoveShip(Ship ship)
    {
        Ships.Remove(ship);
    }
}
