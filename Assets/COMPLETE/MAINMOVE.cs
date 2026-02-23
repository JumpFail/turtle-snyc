using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MAINMOVE : MonoBehaviour
{
    public float moveSpeed = 15f;        // Movement speed of the player
    public float jumpForce = 10f;        // Force applied for jumping
    public float gravityMultiplier = 2f; // Multiplier to increase gravity effect
    public float rotationSpeed = 10f;   // How quickly the player rotates to face the direction

    private Rigidbody rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from WASD or Arrow keys
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(moveX, 0, 0) * moveSpeed;

        // Apply the movement to the Rigidbody
        MovePlayer(movement);

        // Rotate the player to face the direction of movement
        RotatePlayer(moveX, moveZ);

        // Check for jump input
        Jump();

        // Apply custom gravity for faster falling
        ApplyGravity();

        // Update animator parameters
        if (Mathf.Abs(moveX) > 0.01f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void MovePlayer(Vector3 movement)
    {
        // Set the Rigidbody's velocity to the movement vector
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply an upward force to the Rigidbody for jumping
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void ApplyGravity()
    {
        if (rb.velocity.y < 0) // Only apply extra gravity when falling
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (gravityMultiplier - 1) * Time.deltaTime;
        }
    }

    void RotatePlayer(float moveX, float moveZ)
    {
        // If there is any horizontal or vertical movement, rotate the player to face that direction
        Vector3 direction = new Vector3(0, 0, moveX);
        if (direction.magnitude > 0.1f)
        {
            // Calculate the target rotation based on movement direction
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Smoothly rotate the player towards the target direction
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
