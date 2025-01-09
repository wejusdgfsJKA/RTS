using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] protected float spriteDist;
    public List<Ship> ships;
    private void Update()
    {
        DisplayShips();
    }
    protected void DisplayShips()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            Vector3 dir = (ships[i].transform.position - transform.position).normalized;
            ships[i].Symbol.position = transform.position + dir * spriteDist;
            ships[i].Symbol.LookAt(transform);
        }
    }
}
