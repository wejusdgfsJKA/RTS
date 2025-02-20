using System.Collections.Generic;
using UnityEngine;

public enum DmgType { Kinetic, Energy }
public enum TargetType { Hull, Shield }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; protected set; }
    public Dictionary<DmgType, Dictionary<TargetType, float>> DamageModifiers { get; protected set; }
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}
