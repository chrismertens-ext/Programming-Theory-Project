using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    protected override void Awake()
    {
        isPlayer = false;
        moveComplete = true;
        hasJumped = true;

        moveSpeed = 50;
        rotSpeed = 40;
        jumpForce = 50;

        animalRb = GetComponent<Rigidbody>();
    }
}
