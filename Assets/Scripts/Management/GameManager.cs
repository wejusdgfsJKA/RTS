using System;
using System.Collections.Generic;
using UnityEngine;

public enum DmgType { Kinetic = 0, Energy = 1 }
public enum TargetType { Hull = 0, Shield = 1 }

public class GameManager : MonoBehaviour
{
    [Serializable]
    protected class DamageModifier
    {
        [field: SerializeField]
        public DmgType DamageType { get; protected set; }
        [field: SerializeField]
        public TargetType TargetType { get; protected set; }
        [field: SerializeField]
        public float Modifier { get; protected set; }
    }
    public static GameManager Instance { get; protected set; }
    [SerializeField]
    protected List<DamageModifier> modifiers;
    public Dictionary<DmgType, Dictionary<TargetType, float>> DamageModifiers { get; protected set; }
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        for (int i = 0; i < modifiers.Count; i++)
        {
            Dictionary<TargetType, float> col;
            if (DamageModifiers.TryGetValue(modifiers[i].DamageType, out col))
            {
                col.Add(modifiers[i].TargetType, modifiers[i].Modifier);
            }
            else
            {
                DamageModifiers.Add(modifiers[i].DamageType,
                    new Dictionary<TargetType, float>()
                    {
                        { modifiers[i].TargetType,modifiers[i].Modifier }
                    });
            }
        }
    }

}
