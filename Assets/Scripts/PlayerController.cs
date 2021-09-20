using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    Transform aimTransform;
    [SerializeField] GameObject pistol;

    readonly float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        aimTransform = transform.Find("Aim");
    }

    void Update()
    {
        if (!gameManager.IsGameOver)
        {
            Vector3 mousePos = GetMouseWorldPos(Input.mousePosition, Camera.main);
            aimTransform.eulerAngles = new Vector3(0, 0, AngleOfAim(mousePos));

            Shooting();
        }       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.IsGameOver)
        {
            transform.position += HorizontalMovement(speed);
            CheckInBounds();
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

    void CheckInBounds()
    {
        if(transform.position.x >= ScreenSizeManager.instance.Width || transform.position.x <= -ScreenSizeManager.instance.Width)
        {
            Vector3 temp = transform.position;
            if (temp.x > 0)
            {
                temp.x = ScreenSizeManager.instance.Width;
            }else if(temp.x < 0)
            {
                temp.x = -ScreenSizeManager.instance.Width;
            }            
            transform.position = temp;
        }
    }
}
