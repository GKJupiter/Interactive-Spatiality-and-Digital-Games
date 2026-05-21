using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteract : MonoBehaviour
{
    
    public GameObject promptUI;

    
    public string nextSceneName;

    private bool isPlayerInRange = false;

    void Start()
    {
        // Hide the floating text when the game starts
        if (promptUI != null)
        {
            promptUI.SetActive(false);
        }
    }

    void Update()
    {
        // If the player is standing in the trigger AND presses E
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // When the player enters the box, show the text
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            
            if (promptUI != null)
            {
                promptUI.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // When the player walks away, hide the text
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            
            if (promptUI != null)
            {
                promptUI.SetActive(false);
            }
        }
    }
}