using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public bool playerSpawned { get; set; } = false;
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
        float randomXPos = Random.Range(-MainManager.instance.moveRange, MainManager.instance.moveRange);
        float randomZPos = Random.Range(-MainManager.instance.moveRange, MainManager.instance.moveRange);

        Vector3 randomPos = new Vector3(randomXPos, 0, randomZPos);
        
        for (int i = 0; i < MainManager.instance.spawnAmount; i++)
        {
            int animalIndex = Random.Range(0, MainManager.instance.spawnAmount);
            Instantiate(animalPrefabs[animalIndex], randomPos, animalPrefabs[animalIndex].transform.rotation);
        }

        friendsSpawned = true;
    }
}
