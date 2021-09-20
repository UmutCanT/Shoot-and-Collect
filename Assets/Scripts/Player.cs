using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int playerHealth;
    int gemCount;

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
        gemCount = 0;
        UiManager.instance.TextManager(UiManager.instance.playerHp, playerHealth);
        UiManager.instance.TextManager(UiManager.instance.gem, gemCount);
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
            StartCoroutine(UiManager.instance.GameOverUI(gemCount));
            Destroy(gameObject, 1.5f);
        }
    }

    public void AddGem(int gem)
    {
        gemCount += gem;
        UiManager.instance.TextManager(UiManager.instance.gem, gemCount);
    }
}
