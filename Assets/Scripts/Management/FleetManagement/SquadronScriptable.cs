using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Squadron")]
public class SquadronScriptable : ScriptableObject
{
    [field: SerializeField] public List<ShipParams> Ships { get; protected set; } = new();
    [field: SerializeField] public List<SquadronScriptable> Squadrons { get; protected set; } = new();
}