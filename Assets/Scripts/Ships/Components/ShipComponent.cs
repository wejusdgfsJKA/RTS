using UnityEngine;
public class ShipComponent : MonoBehaviour
{
    protected Ship ship;
    protected float signature;
    public float Signature
    {
        get
        {
            return signature;
        }
        set
        {
            if (value >= 0)
            {
                signature = value;
            }
        }
    }
    protected void Awake()
    {
        ship = GetComponentInParent<Ship>();
    }
    protected void OnEnable()
    {
        ship.Signature += signature;
    }
    protected void OnDisable()
    {
        ship.Signature -= signature;
    }
}
