using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab; // The Player prefab you want to spawn
    [SerializeField] Vector3 spawnPosition;   // Where to spawn the player
    [SerializeField] float spawnDelay = 2.0f; // Delay before the player is spawned

    void Start()
    {
        // Invoke the SpawnPlayer method after a delay
        Invoke("SpawnPlayer", spawnDelay * Time.deltaTime);
    }

    // Method to spawn the player
    void SpawnPlayer()
    {
        // Instantiate the player at the specified position and rotation
        Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Player Spawned!");
    }
}
