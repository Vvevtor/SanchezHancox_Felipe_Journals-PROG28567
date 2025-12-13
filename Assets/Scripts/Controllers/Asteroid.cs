using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    private Vector2 asteroidDestination;

    // Start is called before the first frame update
    void Start()
    {
        asteroidDestination = (Random.insideUnitCircle);
        asteroidDestination = asteroidDestination.normalized;
        asteroidDestination = ((asteroidDestination * maxFloatDistance) + (Vector2)transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(asteroidDestination, transform.position) < arrivalDistance) {

            asteroidDestination = (Random.insideUnitCircle);
            asteroidDestination = asteroidDestination.normalized;
            asteroidDestination = ((asteroidDestination * maxFloatDistance) + (Vector2)transform.position);

            transform.position = Vector3.MoveTowards(transform.position, asteroidDestination, moveSpeed * Time.deltaTime);
        }
        else {


            transform.position = Vector3.MoveTowards(transform.position, asteroidDestination, moveSpeed * Time.deltaTime);
        }
    }
}
