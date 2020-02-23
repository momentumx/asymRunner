using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectTypes;
    public Coin coin;
    public Obstacle obstacle;
    private int spawnRate;
    private int x;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnObstacleBottom", 1, 0.3f);
        InvokeRepeating("SpawnObstacleTop", 1, 0.3f);
    }
 

    void SpawnObstacleTop()
    {
        if(GameManager.singleton.isStart == false)
        {
            
            int objectToSpawn = Random.Range(0, objectTypes.Length);
            if (objectToSpawn == 0)
            {
                obstacle.speed = 10;
            }

            else if (objectToSpawn == 1)
            {
                coin.speed = 10;
            }
            float PosY = Random.Range(25f, 30f);
            GameObject gameObject = Instantiate(objectTypes[objectToSpawn], new Vector3(100, PosY, 0), Quaternion.identity) as GameObject;
         
        }
      
    }
    void SpawnObstacleBottom()
    {
        if (GameManager.singleton.isStart == false)
        {
           
            int objectToSpawn = Random.Range(0, objectTypes.Length);
            if (objectToSpawn == 0)
            {
                obstacle.speed = -10;
            }

            else if (objectToSpawn == 1)
            {
                coin.speed = -10;
            }
            float PosY = Random.Range(-66f, -76f);
            Instantiate(objectTypes[objectToSpawn], new Vector3(-100, PosY, 0), Quaternion.identity);
        }

    }
}
