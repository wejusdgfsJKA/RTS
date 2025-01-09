using UnityEngine;
public class Weapon : ShipComponent
{
    public WeaponParameters Parameters { get; set; }
    public bool AngleCheck(Transform target)
    {
        switch (Parameters.AngleType)
        {
            case WeaponParameters.Angle.All:
                return true;
            case WeaponParameters.Angle.Front:
                return Vector3.Angle(transform.forward, target.position -
                    transform.position) <= (180 - Parameters.AngleValue) / 2;
            case WeaponParameters.Angle.Broadside:
                //make sure the targets is not in the front or rear quarters
                var angle = Vector3.Angle(transform.forward, target.position -
                    transform.position);
                return angle >= (180 - Parameters.AngleValue) / 2 && angle <= (180 +
                    Parameters.AngleValue) / 2;
            default:
                return false;
        }
    }
}
