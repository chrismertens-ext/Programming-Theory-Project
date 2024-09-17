using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal
{
    protected override void Awake()
    {
        isPlayer = false;
        moveComplete = true;
        hasJumped = true;

        moveSpeed = 5000;
        rotSpeed = 4000;
        jumpForce = 5000;

        animalRb = GetComponent<Rigidbody>();
    }
}
