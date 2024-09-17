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

        animalRb = GetComponent<Rigidbody>();

        if (MainManager.instance.animalChoice == "Llama")
        {
            moveSpeed = 500;
            rotSpeed = 400;
            jumpForce = 500;
        }

        else if (MainManager.instance.animalChoice == "Elephant")
        {
            moveSpeed = 20000;
            rotSpeed = 16000;
            jumpForce = 20000;
        }

        else if (MainManager.instance.animalChoice == "Cat")
        {
            moveSpeed = 50;
            rotSpeed = 40;
            jumpForce = 50;
        }

        else if (MainManager.instance.animalChoice == "Pig")
        {
            moveSpeed = 750;
            rotSpeed = 600;
            jumpForce = 750;
        }

        else if (MainManager.instance.animalChoice == "Chicken")
        {
            moveSpeed = 12.5f;
            rotSpeed = 10;
            jumpForce = 12.5f;
        }

        else if (MainManager.instance.animalChoice == "Cow")
        {
            moveSpeed = 5000;
            rotSpeed = 4000;
            jumpForce = 5000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
