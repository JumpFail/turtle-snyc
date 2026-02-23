using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class beginningmove : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float jumpForce = 5f;      // Force applied for jumping
    public float gravityMultiplier = 2f; // Multiplier to increase gravity effect

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void Update()
    {
        transform.Translate(0, 0, 0.5f);
        // Get input from WASD or Arrow keys
        float moveX = Input.GetAxis("Horizontal");


        // Create a movement vector based on input
        Vector3 movement = new Vector3(moveX, 0, 0) * moveSpeed;

        // Apply the movement to the Rigidbody
        MovePlayer(movement);

        // Check for jump input
        Jump();

        // Apply custom gravity for faster falling
        ApplyGravity();
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
}
