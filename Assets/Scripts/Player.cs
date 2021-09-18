using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int playerHealth;

    public int PlayerHp
    {
        get
        {
            return playerHealth;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 3;
        UiManager.instance.TextManager(UiManager.instance.playerHp, playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int dmgAmount)
    {
        playerHealth -= dmgAmount;
        UiManager.instance.TextManager(UiManager.instance.playerHp, playerHealth);
        Death(playerHealth);
    }

    void Death(int playerHealth)
    {
        if(playerHealth <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().IsGameOver = true;
            Destroy(gameObject, 1f);
        }
    }
}
