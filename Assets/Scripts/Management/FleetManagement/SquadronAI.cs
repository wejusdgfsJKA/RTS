using System.Collections.Generic;

public class SquadronAI
{
    protected Orders currentOrderEnum;
    public Orders CurrentOrder
    {
        get
        {
            return currentOrderEnum;
        }
        set
        {
            if (value != currentOrderEnum)
            {
                currentOrderEnum = value;
                OnOrderGiven?.Invoke(value, this);
            }
        }
    }
    protected Order currentOrder;
    protected List<System.Tuple<Ship, int>> targetPriorities;
    public event System.Action<Orders, SquadronAI> OnOrderGiven;
    public Squadron Squadron { get; protected set; }
    public SquadronAI(Squadron squadron)
    {
        Squadron = squadron;
    }
    public void Move()
    {
        // move the ships in the squadron based on the squadron's order, then
        // assign orders to subordinates and have them move
        if (currentOrder != null)
        {
            targetPriorities = currentOrder.Move(Squadron);
        }
    }
    public void Shoot()
    {
        //shoot based on the priorities given by the order


    }
    protected void ExecuteShooting(List<System.Tuple<Weapon, ICollection<System.Tuple<Ship, int>>>> targetingData)
    {
        for (int i = 0; i < targetingData.Count; i++)
        {
            targetingData[i].Item1.Fire(targetingData[i].Item2);
        }
    }
    protected List<System.Tuple<Weapon, ICollection<System.Tuple<Ship, int>>>> DetermineTargets()
    {
        //determine targets, assign targets
        throw new System.NotImplementedException();
    }
}
