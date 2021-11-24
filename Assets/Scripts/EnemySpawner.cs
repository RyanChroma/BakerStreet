using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private Vector3 spawnSize;
    [SerializeField] private float spawnRate;
    private float currentDuration = 1;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, spawnSize);
    }

    void Update()
    {
        if(currentDuration > 0)
        {
            currentDuration -= Time.deltaTime;
        }

        else if(currentDuration <= 0)
        {
            currentDuration = spawnRate;
            SpawnEnemyAt(this.transform.position + new Vector3(Random.Range(spawnSize.x/2, -spawnSize.x/2), Random.Range(spawnSize.y/2, -spawnSize.y/2), 0));
        }
    }

    void SpawnEnemyAt(Vector3 pos)
    {
        GameObject enemy = Instantiate(enemyObject, pos, Quaternion.identity);
    }
}
