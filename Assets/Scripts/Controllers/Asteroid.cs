using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float arrivalDistance;
    public float maxFloatDistance;
    private Vector2 asteroidDestination;
    private int asteroidspindirection = 1;
    private float spindeterminer;
    private float speeddeterminer;
    private float maniacalAsteroidSpinner;

    // Start is called before the first frame update
    void Start()
    {
        spindeterminer = Random.value;
        speeddeterminer = Random.value;

        if (spindeterminer >= .5)
        {
            asteroidspindirection = -1 * asteroidspindirection;
        }

        speeddeterminer = speeddeterminer * 10;
        
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

        float fullRadians = Mathf.PI * 2;

        maniacalAsteroidSpinner += ((fullRadians / speeddeterminer) * Time.deltaTime);

        //zero2one += ((1 / drawingTime) * Time.deltaTime);
        //float maniac = ((fullRadians / numberOfPowerups) * i);

        Vector2 maniacalAsteroidRotation = new Vector2(Mathf.Cos(maniacalAsteroidSpinner), Mathf.Sin(maniacalAsteroidSpinner));

        float TRUEMANIACALASTEROIDROTATION = Mathf.Atan2(maniacalAsteroidRotation.y, maniacalAsteroidRotation.x);

        //transform.rotation.eulerAngles.z = transform.rotation.eulerAngles.z + TRUEMANIACALASTEROIDROTATION;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + TRUEMANIACALASTEROIDROTATION);

    }
}
