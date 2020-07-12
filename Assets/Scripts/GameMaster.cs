using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Image iconAccelerate;
    public Image iconTurn;
    public Image iconShoot;

    public Image hp1;
    public Image hp2;
    public Image hp3;

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

    private void colorIcons()
    {
        switch (playerHp)
        {
            case 3:
                hp1.color = Color.red;
                hp2.color = Color.red;
                hp3.color = Color.red;
                
                iconShoot.color = Color.white;
                iconTurn.color = Color.white;
                iconAccelerate.color = Color.white;
                break;
            case 2:
                hp1.color = Color.red;
                hp2.color = Color.red;
                hp3.color = Color.black;
                
                iconShoot.color = Color.black;
                iconTurn.color = Color.white;
                iconAccelerate.color = Color.white;
                break;
            case 1:
                hp1.color = Color.red;
                hp2.color = Color.black;
                hp3.color = Color.black;
                
                iconShoot.color = Color.black;
                iconTurn.color = Color.black;
                iconAccelerate.color = Color.white;
                break;
            case 0:
                hp1.color = Color.black;
                hp2.color = Color.black;
                hp3.color = Color.black;
                
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
