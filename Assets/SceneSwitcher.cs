using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load
    private Vector2 returnPosition;
    public SceneFader sceneFader; // Reference to SceneFader

    private void Start()
    {
        returnPosition = transform.position; // Save the collider's position
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name); // Debug log

        if (other.CompareTag("Player")) // Ensure this is your player
        {
            PlayerPrefs.SetString("ReturnScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetFloat("ReturnPosX", returnPosition.x);
            PlayerPrefs.SetFloat("ReturnPosY", returnPosition.y);
            sceneFader.FadeToScene(sceneToLoad); // Trigger fade and load scene
        }
    }
}
