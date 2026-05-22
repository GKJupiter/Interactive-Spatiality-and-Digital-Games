using UnityEngine;

public class LoopStart : MonoBehaviour
{

    public GameObject leftTrigger_Escape;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the zone is the Player
        if (other.CompareTag("Player"))
        {
            if (leftTrigger_Escape != null)
            {
                leftTrigger_Escape.SetActive(true);
            }
        }
    }
}
