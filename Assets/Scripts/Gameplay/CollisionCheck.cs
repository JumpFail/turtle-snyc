using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLIDED WITH: " + collision.gameObject.name);
    }
}
