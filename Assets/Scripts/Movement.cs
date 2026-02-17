using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 

    private Rigidbody rb;

    private Vector2 moveInput;
    private float jumpInput;

    private bool jumpTriggered;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        jumpInput = value.Get<float>();

        if (jumpInput > 0)
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
