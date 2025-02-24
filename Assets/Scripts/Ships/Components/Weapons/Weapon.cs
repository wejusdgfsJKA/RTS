using UnityEngine;
public class Weapon : MonoBehaviour
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
                dmgInfo = new DmgInfo(transform.parent, value.Damage, value.DamageType, parameters.Accuracy);
            }
        }
    }
    /// <summary>
    /// When was the weapon last fired.
    /// </summary>
    protected float lastFired = -1;
    /// <summary>
    /// True if the weapon is off cooldown.
    /// </summary>
    public bool Ready
    {
        get
        {
            if (lastFired == -1) return true;
            return Time.time - lastFired >= Parameters.Cooldown;
        }
    }
    public void OnEnable()
    {
        lastFired = -1;
    }
    /// <summary>
    /// Is the target in the weapon's firing arc?
    /// </summary>
    /// <param name="target"> The target we want to attack. </param>
    /// <returns>True if the target is in the firing arc.</returns>
    public bool AngleCheck(Transform target)
    {
        switch (parameters.AngleType)
        {
            case WeaponAngle.Front:
                return Vector3.Angle(transform.forward, target.position -
                    transform.position) <= (180 - parameters.AngleValue) / 2;
            case WeaponAngle.Broadside:
                //make sure the targets is not in the front or rear quarters
                var angle = Vector3.Angle(transform.forward, target.position -
                    transform.position);
                return angle >= (180 - parameters.AngleValue) / 2 && angle <= (180 +
                    parameters.AngleValue) / 2;
            default:
                return true;
        }
    }
    /// <summary>
    /// Is the target in range?
    /// </summary>
    /// <param name="target"> The target we want to attack. </param>
    /// <returns>True if the target is in range.</returns>
    public bool DistCheck(Transform target)
    {
        return Vector3.SqrMagnitude(target.position - transform.position) <= parameters.SqrdRange;
    }
    /// <summary>
    /// Attempt to attack a target.
    /// </summary>
    /// <param name="target">The target we want to attack.</param>
    /// <param name="hit">True if the attack hit the target (only if the target was valid).</param>
    /// <returns>True if the target was valid.</returns>
    public bool Attack(Transform target, out bool hit)
    {
        hit = false;
        if (Ready && DistCheck(target) && AngleCheck(target))
        {
            //fire
            lastFired = Time.time;
            return EntityManager.Instance.SendAttack(target, dmgInfo, out hit);
        }
        return false;
    }
}
