using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookDirection : MonoBehaviour
{
    private Vector2 lookInput;
    [SerializeField] private float sensitivity = 0.2f;

    private GameObject cameraPivot;

    private float currentPitch = 0f;
    [SerializeField] private float maxPitch = 80f;

    void Start()
    {
        cameraPivot = transform.GetChild(0).gameObject;
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

    private void OnLook(InputValue value){
        lookInput = value.Get<Vector2>();
    }
}
