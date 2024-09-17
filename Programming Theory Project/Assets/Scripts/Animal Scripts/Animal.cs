using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    protected Rigidbody animalRb;
    public bool isPlayer { get; protected set; }

    public float moveSpeed { get; protected set; } = 20f;
    public float rotSpeed { get; protected set; } = 20f;
    public float jumpForce { get; protected set; } = 20f;

    protected float moveTime;

    public bool moveComplete { get; protected set; }
    public bool hasJumped { get; protected set; }

    private Vector3 cachedRandomDir;
    
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        animalRb = GetComponent<Rigidbody>();
        isPlayer = false;
        moveComplete = true;
        hasJumped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayer)
        {
            if (moveComplete)
            {
                GenerateRandomDirection();

                StartCoroutine(MoveAnimal());
            }

            if (hasJumped)
            {
                StartCoroutine(NPCJump());
            }
        }
    }

    private void GenerateRandomDirection()
    {
        float randomX = Random.Range(-MainManager.instance.moveRange, MainManager.instance.moveRange);
        float randomZ = Random.Range(-MainManager.instance.moveRange, MainManager.instance.moveRange);

        cachedRandomDir = new Vector3(randomX, 0, randomZ);
    }

    protected virtual IEnumerator NPCJump()
    {
        hasJumped = false;
        float randomJumpTime = Random.Range(2, 10);
        
        animalRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        yield return new WaitForSeconds(randomJumpTime);

        hasJumped = true;
    }

    IEnumerator FaceTravelDirection()
    {
        Quaternion startRotation = transform.rotation;
        Vector3 headingDirection = cachedRandomDir - transform.position;
        Quaternion endRotation = Quaternion.LookRotation(headingDirection);

        float rotTimeTotal = 3;
        float rotTimeCurrent = 0f;

        while (rotTimeCurrent <= 1f)
        {
            rotTimeCurrent += Time.deltaTime / rotTimeTotal;
            transform.rotation = Quaternion.Lerp
            (
                startRotation,
                endRotation,
                rotTimeCurrent
            );
            yield return null;
        }
    }

    protected virtual IEnumerator MoveAnimal()
    {
        moveComplete = false;
        
        float moveTimeTotal = Mathf.Round(Random.Range(5, 10));
        float moveTimeCurrent = 0f;

        yield return FaceTravelDirection();

        while (moveTimeCurrent <= 1f)
        {
            if (transform.position != cachedRandomDir)
            {
                moveTimeCurrent += Time.deltaTime / moveTimeTotal;
                transform.position = Vector3.Lerp
                (
                    transform.position,
                    cachedRandomDir,
                    moveTimeCurrent / moveSpeed
                );
                yield return null;
            }
            else
            {
                break;
            }
        }

        moveComplete = true;
    }

    protected virtual void MovePlayer()
    {
        bool onGround;
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y > 0.1f)
        {
            onGround = false;
        }

        else
        {
            onGround = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            animalRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (onGround)
        {
            animalRb.AddForce(transform.forward * forwardInput * moveSpeed);
            animalRb.AddTorque(transform.up * horizontalInput * rotSpeed);
        }

        
    }
}
