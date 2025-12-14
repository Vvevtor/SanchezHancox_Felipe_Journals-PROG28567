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
    private float zero2one = 0;

    // Update is called once per frame
    void Update()
    {
        foreach (Transform asteroidTransform in starTransforms)
        {
            Debug.Log(asteroidTransform.position);
        }


        startpoint = starTransforms[starlistnumber].position;
        endpoint = starTransforms[starlistnumber+1].position;
        zero2one += ((1 / drawingTime) * Time.deltaTime);
        midpoint = Vector2.Lerp(startpoint, endpoint, zero2one);

        Debug.DrawLine(startpoint, midpoint, Color.red);

        if((int)zero2one == (int)1)
        {
            

            zero2one = 0;
            
            starlistnumber++;
            if (starlistnumber == starTransforms.Count-1)
            {
                starlistnumber = 0;
            }
        }
    }
}
