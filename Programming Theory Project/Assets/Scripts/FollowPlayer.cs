using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    public SpawnManager spawnManager;
    private bool playerSet = false;
    public Vector3 cameraOffset = new Vector3(0, 1, -5);
    public float rotationSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "main" && spawnManager.playerSpawned && !playerSet)
        {
            player = GameObject.Find(MainManager.instance.animalChoice + "_player(Clone)");
            playerSet = true;
        }

        if (playerSet)
        {
            transform.position = player.transform.position + cameraOffset;

            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}
