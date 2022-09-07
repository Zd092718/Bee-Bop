using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float spawnRate;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        StartCoroutine(SpawnObstacles());
    }


    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void Spawn()
    {
        int randObstacle = Random.Range(0, obstacles.Length);

        int randomSpot = Random.Range(0, 2); // 0 = top, 1 = bottom

        Quaternion newRot = Quaternion.Euler(0f, 180f, 0f);

        if (randomSpot < 1)
        {
            //spawn at top
            Instantiate(obstacles[randObstacle], spawnPosition, newRot);
        }
        else
        {
            //spawn at bottom
            Vector3 topSpawnPos = new Vector3(spawnPosition.x, 3.71f, spawnPosition.z);
            Quaternion topSpawnRot = Quaternion.Euler(180f, 180f, 0f); 
            Instantiate(obstacles[randObstacle], topSpawnPos, topSpawnRot);
        }


    }
}
