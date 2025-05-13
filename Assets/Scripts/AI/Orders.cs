using System.Collections.Generic;
public enum Orders
{
    /// <summary>
    /// Move with the parent, attack anything within a given range, prioritize 
    /// targets attacking the parent.
    /// </summary>
    Protect,
    /// <summary>
    /// Move with the parent, attack anything in sight, prioritize targets 
    /// attacking the parent.
    /// </summary>
    ProtectAggressive,
    /// <summary>
    /// Attack any target in sight, keep searching for targets until one is found.
    /// </summary>
    Hunt,
    /// <summary>
    /// Attack target.
    /// </summary>
    AttackTarget,
    /// <summary>
    /// Make sure no enemy ships are around the target in a certain radius. 
    /// Surround the target if possible.
    /// </summary>
    IsolateTarget,
    /// <summary>
    /// Same as Protect, but prioritize targets the parent is engaging.
    /// </summary>
    SupportParent,
    /// <summary>
    /// Same as Protect, but prioritize targets the parent is not engaging.
    /// </summary>
    KeepParentClear
}
public abstract class Order
{
    /// <summary>
    /// Move a squadron in a specific way and assign orders to subordinate squadrons.
    /// </summary>
    /// <param name="squadron">The squadron to move.</param>
    /// <returns>A list of targeting priorities to be used for shooting.</returns>
    public abstract List<System.Tuple<Ship, int>> Move(Squadron squadron);
    protected abstract List<System.Tuple<Ship, int>> TargetingPriorities(List<Ship> targets);
}
public class ProtectOrder : Order
{
    protected Ship protectTarget;
    protected float radius;
    public ProtectOrder(Ship ship, float radius)
    {
        protectTarget = ship;
        this.radius = radius;
    }
    public override List<System.Tuple<Ship, int>> Move(Squadron squadron)
    {
        //move in a sphere-like formation unless a threat is sighted
        var targets = TargetingPriorities(FleetManager.Instance.Fleets[squadron.Fleet].Targets);
        if (targets.Count == 0)
        {

        }
        throw new System.NotImplementedException();
    }
    protected override List<System.Tuple<Ship, int>> TargetingPriorities(List<Ship> targets)
    {
        throw new System.NotImplementedException();
    }
}
