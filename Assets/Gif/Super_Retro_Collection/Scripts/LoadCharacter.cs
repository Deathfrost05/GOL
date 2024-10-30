using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public CinemachineVirtualCamera VirtualCamera; // Reference to your virtual camera
    public string playerSortingLayer = "Player"; // Set the correct sorting layer name here
    public int playerSortingOrder = 0;


    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        // Set the virtual camera to follow the instantiated player
        VirtualCamera.Follow = clone.transform;
        
        SpriteRenderer playerRenderer = clone.GetComponent<SpriteRenderer>();
        if (playerRenderer != null)
        {
            playerRenderer.sortingLayerName = playerSortingLayer;
            playerRenderer.sortingOrder = playerSortingOrder;
        }

    }
}