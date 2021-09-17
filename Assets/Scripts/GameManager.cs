using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;
    float spawnInterval = 2f;
    float spawnDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (!isGameOver)
        {
            InvokeRepeating(nameof(SpawnEnemy), spawnDelay, spawnInterval);
        }      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        GameObject enemy = ObjectPooling.instance.GetPooledObjects(ObjectPooling.instance.enemies, 5);
        if(enemy != null)
        {
            enemy.transform.position = SpawnPosition();
            enemy.transform.rotation = Quaternion.identity;;
            enemy.SetActive(true);
        }
    }

    Vector3 SpawnPosition()
    {
        if (Random.Range(0,1) == 1)
        {
            return new Vector3(9, Random.Range(1, 6), 0);
        }
        else
        {
            return new Vector3(-9, Random.Range(1, 6), 0);
        }
    }
}
