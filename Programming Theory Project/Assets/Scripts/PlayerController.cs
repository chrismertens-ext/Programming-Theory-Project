using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Animal
{
    protected override void Awake()
    {
        isPlayer = true;
        moveComplete = false;
        hasJumped = false;
        moveSpeed = 500;
        rotSpeed = 400;
        jumpForce = 500;

        animalRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
