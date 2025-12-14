using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public GameObject powerUpPrefab;
    public List<Transform> asteroidTransforms;
    public Vector2 bombOffset;
    public int numberOfTrailBombs;
    public float inBombSpacing;
    public float inDistance;
    public float howFarSpaceMan;
    public float maxDistFromShip;
    public int numberOfSides = 8;
    public int numberOfBombs = 5;
    public float radarRadius = 1;
    public float bombsRadius = 4;
    public float maxSpeed = 3;
    public float accelerationTime = 3;
    public float spaceShipDashStrength = 3;
    private Vector3 movementInertia;
    public Transform bombsTransform;



    //Vector3 inOffset = new Vector3();
    //Vector3 SpawnBombAtOffset(Vector3 inOffset); //completely clueless, no idea how to make a method. at least by myself at the beginning of class during the first exercise.
    //a method is basically a new "update" type function, I thought it had to be defined up here before deploying it


    // Update is called once per frame
    void Update()
    {

        //DrawRadar(enemyTransform, numberOfSides); done in class, incomplete

        enemyRadar(radarRadius, numberOfSides);

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

        if (Input.GetKeyDown(KeyCode.X))
        {
            SpawnPowerups(bombsRadius, numberOfBombs);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            spaceShipDash(spaceShipDashStrength);
        }

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        // DetectAsteroids(maxDistFromShip, asteroidTransforms);
        // }
    }

    public void spaceShipDash(float spaceShipDashStrength)
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float aDotB = Vector3.Dot(transform.position, mousepos);

        //mousepos = mousepos.normalized;

        Vector2 MANIACALDASHDIRECTION = new Vector2(Mathf.Cos(mousepos.x), Mathf.Sin(mousepos.y));

        float angle = Mathf.Atan2(MANIACALDASHDIRECTION.x, MANIACALDASHDIRECTION.y);

        //movementInertia = movementInertia + new Vector3(;  // I couldn't figure it out in an hour

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

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float fullRadians = Mathf.PI * 2;

        for (int i = 0; i < numberOfPowerups; i++)
        {
            float maniac = ((fullRadians / numberOfPowerups) * i);

            Vector2 maniacalBombSpawnPoint = new Vector2(Mathf.Cos(maniac), Mathf.Sin(maniac)) * radius;

            Instantiate(powerUpPrefab, (transform.position + (Vector3)maniacalBombSpawnPoint), Quaternion.identity);
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

    public void enemyRadar(float radius, int circlePoints)
    {
        UnityEngine.Color decidedColor = Color.green;

        float fullRadians = Mathf.PI * 2 ;

        if (Vector3.Distance(enemyTransform.position, transform.position) < radius) {
            decidedColor = Color.red;
        }


        for (int i = 0; i < circlePoints; i++)
        {
            float maniac = ((fullRadians / circlePoints) * i);
            float maniac2 = ((fullRadians / circlePoints) * (i+1));

            Vector2 maniacalStart = new Vector2(Mathf.Cos(maniac), Mathf.Sin(maniac)) * radius;
            Vector2 maniacalEnd = new Vector2(Mathf.Cos(maniac2), Mathf.Sin(maniac2)) * radius;

            Debug.DrawLine(maniacalStart + (Vector2)transform.position, maniacalEnd + (Vector2)transform.position, decidedColor);
            
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

        

        else if (Input.GetKey(KeyCode.DownArrow))
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

        

        else if (Input.GetKey(KeyCode.LeftArrow))
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

        

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position = transform.position + new Vector3(0.005f, 0, 0);
            movementInertia = movementInertia + new Vector3((((maxSpeed/timeToMaxAccelleration * Time.deltaTime))/100), 0, 0); //IF YOU DIVIDE BY A NUMBER BETWEEN 0 AND 1 IT MAKES A BIGGER NUMBER YOU FOOL

        }

        else
        {
            movementInertia = movementInertia / 1.001f;
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
