using UnityEngine;

public class IllusionTrigger : MonoBehaviour
{
    public Transform destination;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleports the player to the destination's X position, 
            // but keeps their exact Y position so jumping is not interrupted.
            Vector3 newPosition = new Vector3(destination.position.x, other.transform.position.y, other.transform.position.z);
            other.transform.position = newPosition;
        }
    }
}