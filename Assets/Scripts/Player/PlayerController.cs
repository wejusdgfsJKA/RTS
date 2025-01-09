using System;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    protected float xRot, yRot;
    protected Vector2 mouseDelta, wasd;
    protected bool pivoting, highSpeed;
    public float xSens = 1;
    public float ySens = 1;
    public float movSpd = 1;
    public float spdMultiplier = 2;
    public float zoomSpd = .01f;
    protected void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        xRot = yRot = 0;
    }
    protected void Update()
    {
        Vector3 dir = new Vector3(wasd.x, wasd.y, 0).normalized * movSpd * Time.deltaTime;
        if (highSpeed)
        {
            dir *= spdMultiplier;
        }
        transform.Translate(dir, Space.Self);
    }
    public void OnZoom(InputAction.CallbackContext context)
    {
        transform.Translate(new Vector3(0, 0, context.ReadValue<float>() * zoomSpd), Space.Self);
    }
    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
        if (pivoting)
        {
            yRot += mouseDelta.x * ySens;
            xRot -= mouseDelta.y * xSens;
            transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        wasd = context.ReadValue<Vector2>();
    }
    public void OnPivot(InputAction.CallbackContext context)
    {
        pivoting = Convert.ToBoolean(context.ReadValue<float>());
    }
    public void OnSpeed(InputAction.CallbackContext context)
    {
        highSpeed = Convert.ToBoolean(context.ReadValue<float>());
    }
}
