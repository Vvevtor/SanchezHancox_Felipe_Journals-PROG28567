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


    //Vector3 inOffset = new Vector3();
    //Vector3 SpawnBombAtOffset(Vector3 inOffset); //completely clueless, no idea how to make a method. at least by myself at the beginning of class during the first exercise.
    //a method is basically a new "update" type function, I thought it had to be defined up here before deploying it


    // Update is called once per frame
    void Update()
    {

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
}
