using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    private bool playerSpawned = false;
    private bool friendsSpawned = false;

    [SerializeField] private GameObject[] animalPrefabs;
    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "main" && !playerSpawned)
        {
            SpawnPlayer();
        }

        if (SceneManager.GetActiveScene().name == "main" && !friendsSpawned)
        {
            SpawnFriends();
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(Resources.Load(MainManager.instance.animalChoice + "_player"));
        playerSpawned = true;
    }

    private void SpawnFriends()
    {
        for (int i = 0; i < MainManager.instance.spawnAmount; i++)
        {
            int animalIndex = Random.Range(0, MainManager.instance.spawnAmount);
            Instantiate(animalPrefabs[animalIndex]);
        }

        friendsSpawned = true;
    }
}
