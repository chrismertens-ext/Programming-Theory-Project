using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameBannerFollow : MonoBehaviour
{
    public TMP_Text playerIDText;
    private GameObject player;
    public GameObject focalPoint;
    public SpawnManager spawnManager;
    public Vector3 offset = new Vector3(0, 5, 0);

    private bool playerSet = false;

    void Awake()
    {
        playerIDText.text = $"<b>{MainManager.instance.playerName}</b>\n{MainManager.instance.animalChoice}";
    }

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
            transform.position = player.transform.position + offset;
        }
    }
}
