using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookDirection : MonoBehaviour
{
    private Vector2 lookInput;
    [SerializeField] private float sensitivity = 0.2f;
    [SerializeField] private Transform cameraPivot;
    private float currentPitch = 0f;
    [SerializeField] private float maxPitch = 80f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        float yaw = lookInput.x * sensitivity;
        float pitch = lookInput.y * sensitivity;
        transform.Rotate(0f, yaw, 0f);

        currentPitch += pitch;
        currentPitch = Mathf.Clamp(currentPitch, -maxPitch, maxPitch);
        cameraPivot.transform.localRotation = Quaternion.Euler(-currentPitch, 0f, 0f);
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        lookInput = value.ReadValue<Vector2>();
    }
}
