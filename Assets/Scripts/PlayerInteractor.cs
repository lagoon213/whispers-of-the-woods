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

    private void OnPickup(InputValue value)
    {
        if (value.Get<float>() > 0)
        {
            PickupTriggered?.Invoke();
        }
        else
        {
            PickupStopped?.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
