using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    private bool playerSpawned = false;
    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "main" && !playerSpawned)
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(Resources.Load(MainManager.instance.animalChoice + "_player"));
        playerSpawned = true;
    }
}
