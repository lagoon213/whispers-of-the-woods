using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 

    private Rigidbody rb;

    private Vector2 moveInput;
    private bool jumpTriggered;

    [SerializeField] private GameObject yawPivot;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        moveInput = value.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            jumpTriggered = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = yawPivot.transform.right * moveInput.x + yawPivot.transform.forward * moveInput.y;


        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);

        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, 1.1f))
        {
            if (jumpTriggered)
            {
                rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
                jumpTriggered = false;
            }
        }
    }
}
