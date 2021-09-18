using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    CapsuleCollider playerCol;

    float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().IsGameOver)
        {
            transform.position += HorizontalMovement(speed);
        }     
    }

    Vector3 HorizontalMovement(float moveSpeed)
    {
        return (Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime);
    }
}
