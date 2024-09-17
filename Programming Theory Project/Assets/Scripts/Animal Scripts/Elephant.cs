using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Elephant : Animal
{
    protected override void Awake()
    {
        isPlayer = false;
        moveComplete = true;
        hasJumped = true;

        moveSpeed = 20000;
        rotSpeed = 16000;
        jumpForce = 20000;

        animalRb = GetComponent<Rigidbody>();
    }
}
