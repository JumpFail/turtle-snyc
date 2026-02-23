using UnityEngine;

public class cammove2 : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector3 offset;    // The offset of the camera relative to the player
    public float followSpeed = 10f;  // Speed at which the camera follows the player

    void Start()
    {
        // Set the initial offset between the camera and the player
        if (player != null)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        // Ensure player reference exists
        if (player == null)
            return;

        // Calculate the target position for the camera (player position + offset)
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera to the target position using Lerp
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Keep the camera's original rotation (ignores player rotation)
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
