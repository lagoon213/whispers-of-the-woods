using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 

    private Rigidbody rb;

    private Vector2 moveInput;
    private bool jumpTriggered;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

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
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;


        rb.linearVelocity = moveDirection * moveSpeed;

        if (jumpTriggered)
        {
            rb.AddForce(new Vector3(0,10,0), ForceMode.Impulse);
            jumpTriggered = false;
        }
    }
}
