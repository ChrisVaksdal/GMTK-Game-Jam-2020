using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Image iconAccelerate;
    public Image iconTurn;
    public Image iconShoot;

    public GameObject hud;
    public GameObject gameOverScreen;
    public GameObject scoreText;

    private int playerHp;
    private long score;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHp = 3;
        colorIcons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            takeDamage();
        }
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
            scoreText.GetComponent<Text>().text = score.ToString();
        }
        return playerHp;
    }

    public int Heal()
    {
        playerHp += 1;
        playerHp = Math.Max(3, playerHp);
        colorIcons();
        return playerHp;
    }

    private void colorIcons()
    {
        switch (playerHp)
        {
            case 3:                
                iconShoot.color = Color.cyan;
                iconTurn.color = Color.cyan;
                iconAccelerate.color = Color.cyan;
                break;
            case 2:                
                iconShoot.color = Color.black;
                iconTurn.color = Color.white;
                iconAccelerate.color = Color.cyan;
                break;
            case 1:                
                iconShoot.color = Color.black;
                iconTurn.color = Color.black;
                iconAccelerate.color = Color.cyan;
                break;
            case 0:
                iconShoot.color = Color.black;
                iconTurn.color = Color.black;
                iconAccelerate.color = Color.black;
                break;
        }
    }

    public void RestartGame()
    {
        Application.LoadLevel(0);
    }

}
