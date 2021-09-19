using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    CapsuleCollider playerCol;
    Transform aimTransform;
    [SerializeField] GameObject pistol;

    float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCol = GetComponent<CapsuleCollider>();
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().IsGameOver)
        {
            transform.position += HorizontalMovement(speed);

            Vector3 mousePos = GetMouseWorldPos(Input.mousePosition, Camera.main);
            aimTransform.eulerAngles = new Vector3(0, 0, AngleOfAim(mousePos));

            Shooting();
        }     
    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = ObjectPooling.instance.GetPooledObjects(ObjectPooling.instance.bullets, ObjectPooling.instance.AmountofObject(2));
            if (bullet != null)
            {
                bullet.transform.position = pistol.transform.position;
                bullet.transform.rotation = pistol.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    Vector3 HorizontalMovement(float moveSpeed)
    {
        return (Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime);
    }

    Vector3 GetMouseWorldPos(Vector3 screenPos, Camera mainCam)
    {
        Vector3 pos = mainCam.ScreenToWorldPoint(screenPos);
        pos.z = 0;
        return pos;
    }

    float AngleOfAim(Vector3 mousePos)
    {
        return Mathf.Atan2(DirectionOfAim(mousePos).y, DirectionOfAim(mousePos).x) * Mathf.Rad2Deg;
    }

    Vector3 DirectionOfAim(Vector3 mousePos)
    {
        return (mousePos - transform.position).normalized;
    }
}
