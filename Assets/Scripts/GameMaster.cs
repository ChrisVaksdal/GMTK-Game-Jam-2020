using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public GameObject player;

    public Image iconAccelerate;
    public Image iconTurn;
    public Image iconShoot;

    public GameObject hud;
    public GameObject hudScoreText;
    public GameObject gameOverScreen;
    public AudioSource healAudio;
    public AudioSource shieldAudio;
    public GameObject gameOverScoreText;
    public AudioSource gameOverAudio;
    public AudioSource gameMusicAudio;
    private int playerHp;
    public static long score;

    private GameObject playerModel;
    private GameObject statueModel;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = 3;
        colorIcons();
        playerModel = player.transform.Find("SpaceShip").gameObject;
        statueModel = player.transform.Find("statue_head").gameObject;
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
            gameOverScoreText.GetComponent<TextMeshProUGUI>().text = "SCORE: " + score.ToString();
            gameOverAudio.Play();
            gameMusicAudio.volume *= 0.3f;
            player.GetComponent<ParticleSystem>().Play();
            playerModel.SetActive(false);
            player.GetComponent<Collider>().enabled = false;
            //gameMusicAudio.Stop();
            //gameMusicAudio.Play();
        }
        else if (playerHp == 3)
        {
            playerModel.SetActive(true);
            statueModel.SetActive(false);
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

    public void ShieldPowerUp()
    {
        playerHp = 4;
        colorIcons();
        shieldAudio.Play();
        playerModel.SetActive(false);
        statueModel.SetActive(true);
    }

    private void colorIcons()
    {
        Color yesColor = new Color32(0x36, 0xE7, 0xE4, 0xFF);   // Cyan
        Color noColor = Color.black;
        switch (playerHp)
        {
            case 4:
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
