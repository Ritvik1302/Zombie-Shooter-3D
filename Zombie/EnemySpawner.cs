using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] enemySpawnPoints;
    public float spawnDuration = 5f;
    // Startis called before the first frame update
    void Start()
    {
        enemySpawnPoints = new Transform[transform.childCount];
        for(int i=0;i<transform.childCount;i++)
        {
            enemySpawnPoints[i]=transform.GetChild(i);
        }
        StartCoroutine(CoStartSpawning());
    }

    IEnumerator CoStartSpawning()
    {
        while(true)
        {
            for(int i=0;i<enemySpawnPoints.Length;i++)
            {
                Transform enemySpawnPoint = enemySpawnPoints[i];
            Instantiate(zombiePrefab,enemySpawnPoint.position,enemySpawnPoint.rotation);
            }
          yield return new WaitForSeconds(spawnDuration);
        }
    }
}
