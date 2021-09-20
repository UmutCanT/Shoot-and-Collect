using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> bullets = new List<GameObject>();
    public List<GameObject> fireballs = new List<GameObject>();
    public List<GameObject> gems = new List<GameObject>();
    
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject fireball;
    [SerializeField] GameObject gem;

    int enemyAmount = 5;
    int bulletAmount = 30;
    int fbAmount = 10;
    int gemAmount = 10;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatingObjectsToPool(enemies, enemy, enemyAmount);
        CreatingObjectsToPool(bullets, bullet, bulletAmount);
        CreatingObjectsToPool(fireballs, fireball, fbAmount);
        CreatingObjectsToPool(gems, gem, gemAmount);
    }

    void CreatingObjectsToPool(List<GameObject> listToHold ,GameObject obj, int amount)
    {
        GameObject tmp;
        for (int i = 0; i < amount; i++)
        {
            tmp = Instantiate(obj);
            tmp.SetActive(false);
            listToHold.Add(tmp);
        }
    }

    public GameObject GetPooledObjects(List<GameObject> objList,int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (!objList[i].activeInHierarchy)
            {
                return objList[i];
            }
        }
        return null;
    }

    public int AmountofObject(int type)
    {
        return type switch
        {
            1 => enemyAmount,
            2 => bulletAmount,
            3 => fbAmount,
            4 => gemAmount,
            _ => default
        };
    }
}
