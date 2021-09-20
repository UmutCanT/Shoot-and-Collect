using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    readonly float bulletSpeed = 30f;
    float xBulletRange; 
    float ybulletRange; 

    void Start()
    {
        xBulletRange = ScreenSizeManager.instance.Width;
        ybulletRange = ScreenSizeManager.instance.Height + 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().IsGameOver)
        {
            Destroy(gameObject);
        }

        if (gameObject.activeInHierarchy)
        {
            transform.position += transform.up * bulletSpeed * Time.deltaTime;
        }

        CheckInBounds();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            GemBonus();
        }

        gameObject.SetActive(false);
    }

    void CheckInBounds()
    {
        if (transform.position.x > xBulletRange || transform.position.x < -xBulletRange || transform.position.y > ybulletRange || transform.position.y < -ybulletRange)
        {
            gameObject.SetActive(false);
        }
    }

    void GemBonus()
    {
        GameObject gem = ObjectPooling.instance.GetPooledObjects(ObjectPooling.instance.gems, ObjectPooling.instance.AmountofObject(4));
        if (gem != null)
        {
            gem.transform.position = transform.position;
            gem.transform.rotation = Quaternion.identity;
            gem.SetActive(true);
        }
    }
}
