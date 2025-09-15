using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    //Vector3 inOffset = new Vector3();
    //Vector3 SpawnBombAtOffset(Vector3 inOffset); //completely clueless, no idea how to make a method. at least by myself at the beginning of class during the first exercise.
    //a method is basically a new "update" type function, I thought it had to be defined up here before deploying it


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0, 1));
        }
        
    }

    private void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawnPosition = transform.position + inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    } 
}
