using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Pig : Animal
{
    protected override void Awake()
    {
        isPlayer = false;
        moveComplete = true;
        hasJumped = true;

        moveSpeed = 750;
        rotSpeed = 600;
        jumpForce = 750;

        animalRb = GetComponent<Rigidbody>();
    }
}
