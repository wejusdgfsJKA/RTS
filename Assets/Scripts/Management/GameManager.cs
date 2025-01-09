using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected float HullEnergyDmgMultiplier = 1;
    [SerializeField] protected float HullBallisticDmgMultiplier = 1;
    [SerializeField] protected float ShieldEnergyDmgMultiplier = 1;
    [SerializeField] protected float ShieldBallisticDmgMultiplier = 1;
    protected void Awake()
    {
        Numbers.ShieldEnergyDmgMultiplier = ShieldEnergyDmgMultiplier;
        Numbers.HullEnergyDmgMultiplier = HullEnergyDmgMultiplier;
        Numbers.HullBallisticDmgMultiplier = HullBallisticDmgMultiplier;
        Numbers.ShieldBallisticDmgMultiplier = ShieldBallisticDmgMultiplier;
    }
}
