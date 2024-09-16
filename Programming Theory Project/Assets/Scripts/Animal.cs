using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected Rigidbody animalRb;
    protected float moveSpeed = 20f;
    protected float rotSpeed = 20f;
    protected float moveRange = 17.5f;
    protected float moveTime;
    private bool moveComplete;
    private Vector3 cachedRandomDir;
    
    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        moveComplete = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveComplete)
        {
            GenerateRandomDirection();

            StartCoroutine(MoveAnimal());
        }
    }

    private void GenerateRandomDirection()
    {
        float randomX = Random.Range(-moveRange, moveRange);
        float randomZ = Random.Range(-moveRange, moveRange);

        cachedRandomDir = new Vector3(randomX, 0, randomZ);
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

    IEnumerator MoveAnimal()
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
}
