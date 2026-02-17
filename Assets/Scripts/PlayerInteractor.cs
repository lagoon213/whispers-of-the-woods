using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public static event Action PickupTriggered;
    public static event Action PickupStopped;

    public void OnPickup(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            PickupTriggered?.Invoke();
        }
        else if (value.canceled)
        {
            PickupStopped?.Invoke();
        }
    }
}
