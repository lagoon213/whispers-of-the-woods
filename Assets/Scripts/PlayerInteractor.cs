using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public static event Action PickupTriggered;
    public static event Action PickupStopped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
