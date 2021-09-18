using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public TextMeshProUGUI playerHp;
    public TextMeshProUGUI gem;
 
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHp.text = "HP: ";
        gem.text = "Gem: ";
    }

    // Update is called once per frame
    void Update()
    {
        
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
            _ => default
        };
    }
}
