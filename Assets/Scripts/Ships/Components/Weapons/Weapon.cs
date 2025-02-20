using UnityEngine;
public class Weapon : ShipComponent
{
    protected DmgInfo dmgInfo;
    protected WeaponParameters parameters;
    public WeaponParameters Parameters
    {
        get
        {
            return parameters;
        }
        set
        {
            if (value != null && parameters == null)
            {
                parameters = value;
                signature = value.Signature;
                dmgInfo = new DmgInfo(transform.parent, value.Damage, value.DamageType);
            }
        }
    }
    public bool AngleCheck(Transform target)
    {
        switch (parameters.AngleType)
        {
            case WeaponParameters.Angle.Front:
                return Vector3.Angle(transform.forward, target.position -
                    transform.position) <= (180 - parameters.AngleValue) / 2;
            case WeaponParameters.Angle.Broadside:
                //make sure the targets is not in the front or rear quarters
                var angle = Vector3.Angle(transform.forward, target.position -
                    transform.position);
                return angle >= (180 - parameters.AngleValue) / 2 && angle <= (180 +
                    parameters.AngleValue) / 2;
            default:
                return true;
        }
    }
    public bool DistCheck(Transform target)
    {
        return Vector3.SqrMagnitude(target.position - transform.position) <= parameters.SqrdRange;
    }
    public bool Attack(Transform target)
    {
        if (DistCheck(target) && AngleCheck(target))
        {
            for (int i = 0; i < parameters.Attacks; i++)
            {
                if (!EntityManager.Instance.SendAttack(target, dmgInfo))
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}
