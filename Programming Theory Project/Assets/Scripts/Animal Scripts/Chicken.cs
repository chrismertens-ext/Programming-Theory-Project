using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Chicken : Animal
{
    protected override void Awake()
    {
        isPlayer = false;
        moveComplete = true;
        hasJumped = true;

        moveSpeed = 12.5f;
        rotSpeed = 10;
        jumpForce = 12.5f;

        animalRb = GetComponent<Rigidbody>();
    }
}
