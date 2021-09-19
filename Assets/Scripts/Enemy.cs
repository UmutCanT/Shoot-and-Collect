using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    float enemySpeed;
    //Get this value from screen size manager
    float maxBound = 9f;
    float xEnemyPos;
    float fireDelay = 1.5f;
    float fireInterval;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Did the enemy spawn which side of the screen?
        xEnemyPos = transform.position.x;
        enemySpeed = Random.Range(3f, 15f);
        fireInterval = Random.Range(2f, 4f);
        InvokeRepeating(nameof(Fireball), fireDelay, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.IsGameOver)
        {
            transform.position = HorizontalMovement(maxBound, xEnemyPos);
        }
        else
        {
            Destroy(gameObject);
        }      
    }

    Vector3 HorizontalMovement(float max, float decider)
    {
        if(decider > 0)
        {
            return new Vector3(-(Mathf.PingPong(Time.time * enemySpeed, 2 * max) - max), transform.position.y, transform.position.z);
        }
        else
        {
            return new Vector3(Mathf.PingPong(Time.time * enemySpeed, 2 * max) - max, transform.position.y, transform.position.z);
        }        
    }

    void Fireball()
    {
        GameObject fireball = ObjectPooling.instance.GetPooledObjects(ObjectPooling.instance.fireballs, ObjectPooling.instance.AmountofObject(3));
        if (fireball != null)
        {
            fireball.transform.position = transform.position;
            fireball.transform.rotation = Quaternion.identity;
            fireball.SetActive(true);
        }
    }
}
