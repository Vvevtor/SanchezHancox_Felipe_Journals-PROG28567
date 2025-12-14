using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitalspeed = 1.0f; //a speed of 1 = 1 radian per second
    public float radius = 3.0f;
    public float maniacalzero2twopi = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fullRadians = Mathf.PI * 2;

        maniacalzero2twopi += ((fullRadians / orbitalspeed) * Time.deltaTime);

        //zero2one += ((1 / drawingTime) * Time.deltaTime);
        //float maniac = ((fullRadians / numberOfPowerups) * i);

        Vector2 maniacalPlanetPostion = new Vector2(Mathf.Cos(maniacalzero2twopi), Mathf.Sin(maniacalzero2twopi)) * radius;

        transform.position = planetTransform.position + (Vector3)maniacalPlanetPostion;

        if ((int)maniacalzero2twopi == (int)360)
        {
            maniacalzero2twopi = 0;
        }



    }
}
