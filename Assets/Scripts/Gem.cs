using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.Rotate(Vector3.one, 5f);         
        }

        if (GameObject.Find("GameManager").GetComponent<GameManager>().IsGameOver)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().AddGem(1);
        }
        gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
    }
}
