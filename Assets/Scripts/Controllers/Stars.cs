using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    private Vector2 startpoint; 
    private Vector2 endpoint;
    private Vector2 midpoint;
    private int starlistnumber = 0;

    // Update is called once per frame
    void Update()
    {
        foreach (Transform asteroidTransform in starTransforms)
        {
            Debug.Log(asteroidTransform.position);
        }


        startpoint = starTransforms[starlistnumber].position;
        endpoint = starTransforms[starlistnumber+1].position;
        midpoint = Vector2.Lerp()

        Debug.DrawLine(startpoint, endpoint, Color.red);

    }
}
