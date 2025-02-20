using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/SensorParameters")]
public class SensorParameters : ScriptableObject
{
    [field: SerializeField] public float Signature { get; protected set; }
    [field: SerializeField] public float Range { get; protected set; }
}
