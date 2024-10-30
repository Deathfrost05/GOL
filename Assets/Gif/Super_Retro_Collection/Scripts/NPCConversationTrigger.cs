using UnityEngine;
using UnityEngine.UI;  // Import for UI Text
using TMPro;           // Import for TextMeshPro

public class NPCConversationTrigger : MonoBehaviour
{
    public GameObject convoPanel;         // Reference to the conversation panel
    public Transform playerTransform;     // Reference to the Player's Transform
    public TextMeshProUGUI convoText;     // Reference to the TextMeshPro Text component
    // If using the built-in Text UI component, use `public Text convoText;` instead

    [TextArea]
    public string conversationMessage = "Hello, Player! Welcome to our village.";  // Default conversation text

    private void Start()
    {
        // Ensure the convoPanel is initially disabled
        if (convoPanel != null)
        {
            convoPanel.SetActive(false);
            convoText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the collider
        if (other.transform == playerTransform)
        {
            convoPanel.SetActive(true);       // Show the conversation panel
            convoText.text = conversationMessage;  // Set the conversation text
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exited the collider
        if (other.transform == playerTransform)
        {
            convoPanel.SetActive(false);     // Hide the conversation panel
            convoText.text = "";             // Clear the conversation text
        }
    }
}
