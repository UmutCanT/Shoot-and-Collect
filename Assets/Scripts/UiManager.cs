using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject gameOverPanel;

    public TextMeshProUGUI playerHp;
    public TextMeshProUGUI gem;
    public TextMeshProUGUI endScoreText;
 
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerUI.SetActive(true);
        gameOverPanel.SetActive(false);
        playerHp.text = "HP: ";
        gem.text = "Gem: ";
    }

    public void TextManager(TextMeshProUGUI textToChange, int value)
    {   
        textToChange.text = string.Format(FormatDecider(textToChange), value); 
    }

    string FormatDecider(TextMeshProUGUI textToFormat)
    {
        return textToFormat.name switch
        {
            "PlayerHP" => "HP: {0}",
            "GemAmount" => "Gem: {0}",
            "ScoreTitle" => "Score: {0}",
            _ => default
        };
    }

    public IEnumerator GameOverUI(int endScore)
    {
        yield return new WaitForSeconds(0.5f);
        playerUI.SetActive(false);
        TextManager(endScoreText, endScore);
        gameOverPanel.SetActive(true);
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
