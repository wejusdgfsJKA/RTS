using UnityEngine;

public class Symbol : MonoBehaviour
{
    [SerializeField] protected float scale;
    protected void LateUpdate()
    {
        if (Camera.main != null)
        {
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        }
        transform.localScale = scale * Vector3.one * Vector3.Distance(
            transform.position, Camera.main.transform.position);
    }
}
