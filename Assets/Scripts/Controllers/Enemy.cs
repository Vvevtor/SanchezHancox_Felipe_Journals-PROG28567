using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float enemyspeed;

    private void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyspeed * Time.deltaTime);

    }

}
