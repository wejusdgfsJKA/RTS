using UnityEngine;
public class Weapon : ShipComponent
{
    public enum DmgType { Ballistic, Energy }
    public enum Angle { Front, Broadside, All }
    [field: SerializeField] public DmgType DamageType { get; protected set; }
    [field: SerializeField] public Angle AngleType { get; protected set; }
    [field: SerializeField] public float AngleValue { get; protected set; }
    public bool AngleCheck(Transform target)
    {
        switch (AngleType)
        {
            case Angle.All:
                return true;
            case Angle.Front:
                return Vector3.Angle(transform.root.forward, target.position -
                    transform.root.position) <= (180 - AngleValue) / 2;
            case Angle.Broadside:
                //make sure the targets is not in the front or rear quarters
                var angle = Vector3.Angle(transform.root.forward, target.position -
                    transform.root.position);
                return angle >= (180 - AngleValue) / 2 && angle <= (180 + AngleValue) / 2;
            default:
                return false;
        }
    }
}
