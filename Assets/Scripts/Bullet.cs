using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        if(transform.position.x > 9f || transform.position.x < -9f || transform.position.y > 7f)
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
