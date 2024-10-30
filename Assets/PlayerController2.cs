using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public GameObject playerPrefab; // Assign your player prefab in the inspector
    private static GameObject playerInstance;

    private void Awake()
    {
        if (playerInstance == null)
        {
            playerInstance = Instantiate(playerPrefab);
            DontDestroyOnLoad(playerInstance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
