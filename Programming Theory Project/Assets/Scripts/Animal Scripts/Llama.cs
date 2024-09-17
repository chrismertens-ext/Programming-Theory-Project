using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llama : Animal
{
    protected override void Awake()
    {
        isPlayer = false;
        moveComplete = true;
        hasJumped = true;

        moveSpeed = 500;
        rotSpeed = 400;
        jumpForce = 500;

        animalRb = GetComponent<Rigidbody>();
    }
}
