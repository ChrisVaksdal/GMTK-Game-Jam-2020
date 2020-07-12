using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public Image iconAccelerate;
    public Image iconTurn;
    public Image iconShoot;

    public GameObject hud;
    public GameObject hudScoreText;
    public GameObject gameOverScreen;
    public AudioSource healAudio;
    public GameObject gameOverScoreText;
    private int playerHp;
    public static long score;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHp = 3;
        colorIcons();
    }

    // Update is called once per frame
    void Update()
    {
        hudScoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    private void FixedUpdate()
    {
        score += 1;
    }

    public int getPlayerHp()
    {
        return playerHp;
    }

    public int takeDamage()
    {
        playerHp -= 1;
        colorIcons();
        if (playerHp == 0)
        {
            gameOverScreen.SetActive(true);
            hud.SetActive(false);
            gameOverScoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        }
        return playerHp;
    }

    public int Heal()
    {
        playerHp += 1;
        playerHp = Math.Min(3, playerHp);
        colorIcons();
        healAudio.Play();
        return playerHp;
    }

    private void colorIcons()
    {
        //Color yesColor = new Color32(0x00, 0xDB, 0x75, 0xFF); // Light-green
        Color yesColor = new Color32(0x36, 0xE7, 0xE4, 0xFF);   // Cyan
        Color noColor = Color.black;
        switch (playerHp)
        {
            case 3:                
                iconShoot.color = yesColor;
                iconTurn.color = yesColor;
                iconAccelerate.color = yesColor;
                break;
            case 2:                
                iconShoot.color = noColor;
                iconTurn.color = yesColor;
                iconAccelerate.color = yesColor;
                break;
            case 1:                
                iconShoot.color = noColor;
                iconTurn.color = noColor;
                iconAccelerate.color = yesColor;
                break;
            case 0:
                iconShoot.color = noColor;
                iconTurn.color = noColor;
                iconAccelerate.color = noColor;
                break;
        }
    }

    public void RestartGame()
    {
        Application.LoadLevel(0);
    }

}
