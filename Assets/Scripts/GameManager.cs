using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;
    readonly float spawnInterval = 2f;
    readonly float spawnDelay = 1f;
    float xEnemyPos; 

    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }

        set
        {
            isGameOver = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        xEnemyPos = ScreenSizeManager.instance.Width;
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, spawnInterval);       
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            CancelInvoke(nameof(SpawnEnemy));
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = ObjectPooling.instance.GetPooledObjects(ObjectPooling.instance.enemies, ObjectPooling.instance.AmountofObject(1));
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
            return new Vector3(xEnemyPos, Random.Range(1, 6), 0);
        }
        else
        {
            return new Vector3(-xEnemyPos, Random.Range(1, 6), 0);
        }
    }
}
