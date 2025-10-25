using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    public Vector2 bombOffset;
    public int numberOfTrailBombs;
    public float inBombSpacing;
    public float inDistance;
    public float howFarSpaceMan;
    public float maxDistFromShip;
    public float numberOfSides;
    public float maxSpeed;
    public float accelerationTime;
    private Vector3 movementInertia;



    //Vector3 inOffset = new Vector3();
    //Vector3 SpawnBombAtOffset(Vector3 inOffset); //completely clueless, no idea how to make a method. at least by myself at the beginning of class during the first exercise.
    //a method is basically a new "update" type function, I thought it had to be defined up here before deploying it


    // Update is called once per frame
    void Update()
    {

        DrawRadar(enemyTransform, numberOfSides);

        PlayerMovement(maxSpeed, accelerationTime);

        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(bombOffset.x, bombOffset.y));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnBombTrail(inBombSpacing, numberOfTrailBombs);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnBombOnRandomCorner(inDistance);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            WarpPlayer(enemyTransform, howFarSpaceMan);
        }

        //if (Input.GetKeyDown(KeyCode.F))
        //{
           // DetectAsteroids(maxDistFromShip, asteroidTransforms);
       // }
    }

    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawnPosition = transform.position + inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }


    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {

        
         
        for (int i = 0; i < inNumberOfBombs; i++)
        {

            
            Vector3 spawnPosition = transform.position + new Vector3(0f, -(inBombSpacing * i) - 0.5f, 0f);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }




    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        int location = Random.Range(1, 5);

        if (location == 1)
        {
            Vector3 spawnPosition = transform.position + ((Vector3.up + Vector3.right) * inDistance);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }
        else if (location == 2)
        {
            Vector3 spawnPosition = transform.position + ((Vector3.up + Vector3.left) * inDistance);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }
        else if (location == 3)
        {
            Vector3 spawnPosition = transform.position + ((Vector3.down + Vector3.left) * inDistance);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }
        else if (location == 4)
        {
            Vector3 spawnPosition = transform.position + ((Vector3.down + Vector3.right) * inDistance);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }

    }

    //public void spawnEnemy();

    public void WarpPlayer(Transform target, float ratio)
    {
        //Vector3 tempLocation = transform.position;
        //tempLocation.Lerp(transform.position, target.position, ratio); //dunno what I was cooking here.
        transform.position = Vector3.Lerp(transform.position, target.position, ratio);
    }


   // public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
 //   {
  //      foreach (int i in inAsteroids) 
  //      {


   //         Vector3 spawnPosition = transform.position + new Vector3(0f, -(inBombSpacing * i) - 0.5f, 0f);
//            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);


   //     }


    public void DrawRadar(Transform enemyposition, float howManySides)
    {
        UnityEngine.Color decidedColor = Color.green;

        // if (close to enemy, decidedcolor = Color.red)

        for (int i = 0; i < howManySides; i++)
        {

            //Debug.DrawLine(xxx, xxx, decidedColor); // I got completely stuck here, got lost in the sin cos sauce. 
        }



        



    }

    public void PlayerMovement(float whereToClamp, float timeToMaxAccelleration)
    {



        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position = transform.position + new Vector3(0, 0.005f, 0);
            movementInertia = movementInertia + new Vector3(0, (((maxSpeed / timeToMaxAccelleration * Time.deltaTime)) / 100), 0); //james explained time.deltatime to me
        }

//        //else if (movementInertia.y > 0)
//        //{
//          //  movementInertia.y = movementInertia.y - 0.05f;

////        }

//  //      if (movementInertia.y >= 0.01f && movementInertia.y <= 0.1f)
//        {
//            movementInertia.y = 0;
//        }

        

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position = transform.position + new Vector3(0, -0.005f, 0);
            movementInertia = movementInertia + new Vector3(0, -(((maxSpeed / timeToMaxAccelleration * Time.deltaTime)) / 100), 0);

        }

        //else if (movementInertia.y < 0)
        //{
        //    movementInertia.y = movementInertia.y + 0.05f;

        //}

        //if (movementInertia.y <= -0.01f && movementInertia.y >= -0.1f)
        //{
        // movementInertia.y = 0;
        //}

        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position = transform.position + new Vector3(-0.005f, 0, 0);
            movementInertia = movementInertia + new Vector3(-(((maxSpeed/timeToMaxAccelleration * Time.deltaTime))/100), 0, 0);
            
        }

        //else if (movementInertia.x < 0)
        //{
        //    movementInertia.x = movementInertia.x + 0.05f;

        //}

        //if (movementInertia.x <= -0.01f && movementInertia.x >= -0.1f)
        //{
        //    movementInertia.x = 0;
        //}

        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position = transform.position + new Vector3(0.005f, 0, 0);
            movementInertia = movementInertia + new Vector3((((maxSpeed/timeToMaxAccelleration * Time.deltaTime))/100), 0, 0); //IF YOU DIVIDE BY A NUMBER BETWEEN 0 AND 1 IT MAKES A BIGGER NUMBER YOU FOOL

        }

        //else if (movementInertia.x > 0)
        //{
        //    movementInertia.x = movementInertia.x - 0.05f;

        //}

        //if (movementInertia.x >= 0.01f && movementInertia.x <= 0.1f)
        //{
        //    movementInertia.x = 0;
        //}

        

        //Debug.Log(movementInertia.magnitude);

        movementInertia = Vector3.ClampMagnitude(movementInertia, maxSpeed);

        //transform.position += new Vector3(movementInertia.x, movementInertia.y, 0);

        transform.position += movementInertia;

        //transform.position = Vector3.ClampMagnitude(transform.position, maxSpeed); // james showed me how clamp magnitude works

        Debug.Log(movementInertia.ToString());
        

    }


}
