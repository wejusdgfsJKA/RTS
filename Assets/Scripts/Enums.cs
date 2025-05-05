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

public enum ShipType
{
    Cruiser
}