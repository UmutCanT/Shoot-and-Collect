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
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
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
}
