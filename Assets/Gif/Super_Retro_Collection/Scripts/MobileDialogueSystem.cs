using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
[System.Serializable]
public struct Dialog
{
    public string speaker;  // The name of the character speaking
    public string text;     // The dialogue text
    public string[] responses; // Available player responses
}

public class MobileDialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI SpeakerText;
    public TextMeshProUGUI DialogText;
    //public Text SpeakerText;       // UI Text for the speaker's name
    //public Text DialogText;        // UI Text for the dialog text
    public Button responseButtonPrefab;  // Button prefab for responses
    public Transform responseContainer;  // UI container for response buttons
    public GameObject dialogUI;    // The entire dialog UI to show/hide
    public KeyCode interactionKey = KeyCode.E; // Key to initiate dialog (for desktop testing)

    private int currentDialogIndex = 0; // Tracks the current dialogue index
    private Dialog[] dialogs; // Array to hold all dialogues
    private bool isPlayerInRange = false; // Check if player is in range to interact

    void Start()
    {
        // Initially hide dialog UI
        dialogUI.SetActive(false);

        // Initialize the dialog sequence
        dialogs = new Dialog[]
        {
            new Dialog {
                speaker = "Elder:",
                text = "Young one, this forest was once lush and full of life, but now it suffers due to harmful actions by careless hands.",
                responses = new string[] { "What happened here?", "Who would harm such beauty?" }
            },
            new Dialog {
                speaker = "Hero:",
                text = "What happened here? Who would harm such beauty?",
                responses = new string[] { "awd" }
            },
            new Dialog {
                speaker = "Elder:",
                text = "Illegal activities, such as logging and dumping waste, have poisoned the soil and air, leaving creatures without homes and food.",
                responses = new string[] { "Is there any way to fix it?", "I can't believe it's come to this." }
            },
            new Dialog {
                speaker = "Hero:",
                text = "Is there any way to fix it?\", \"I can't believe it's come to this?",
                responses = new string[] { "awd" }
            },
            new Dialog {
                speaker = "Elder:",
                text = "There is a way, but it will not be easy. The forest needs the care of someone with the courage and will to restore it.",
                responses = new string[] { "I値l help! Tell me what I can do.", "Why me?" }
            },
            new Dialog {
                speaker = "Hero:",
                text = "I値l help! Tell me what I can do.\", \"Why me?",
                responses = new string[] { "awd" }
            },
            new Dialog {
                speaker = "Elder:",
                text = "You have a pure heart, young one. You must plant trees, clean the water, and rally others to respect nature once more.",
                responses = new string[] { "I understand. I値l do my best.", "I値l make sure others join us." }
            },
            new Dialog {
                speaker = "Hero:",
                text = "Thank you, Elder. I値l restore the forest and bring back the life it once held.",
                responses = new string[] { "End" }
            }
        };
    }

    void Update()
    {
        // Check if player is in range and presses the interaction key
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            ShowDialog();
        }
    }

    void ShowDialog()
    {
        dialogUI.SetActive(true);  // Show dialog UI
        DisplayCurrentDialog();
    }

    


    void DisplayCurrentDialog()
    {
        // Clear existing response buttons
        foreach (Transform child in responseContainer)
        {
            Destroy(child.gameObject);
        }

        if (currentDialogIndex < dialogs.Length)
        {
            Dialog dialog = dialogs[currentDialogIndex];

            // Update the UI elements with dialog data
            SpeakerText.text = dialog.speaker;
            DialogText.text = dialog.text;

            // Create response buttons
            foreach (string response in dialog.responses)
            {
                Button responseButton = Instantiate(responseButtonPrefab, responseContainer);
                Debug.Log("Button instantiated");
                responseButton.onClick.RemoveAllListeners(); // Clears previous listeners
                responseButton.onClick.AddListener(OnResponseSelected);

                responseButton.GetComponentInChildren<Text>().text = response;
                responseButton.onClick.AddListener(() => OnResponseSelected());
            }
        }
    }

    void OnResponseSelected()
    {
        // Advance to the next dialog entry
        currentDialogIndex++;
        DisplayCurrentDialog();
    }


    void HideDialog()
    {
        dialogUI.SetActive(false);  // Hide dialog UI
        currentDialogIndex = 0;     // Reset dialog to the beginning
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; // Player is now in range to interact
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // Player left range, hide dialog
            HideDialog();
        }
    }
}
