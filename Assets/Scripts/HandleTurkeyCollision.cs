using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTurkeyCollision : MonoBehaviour
{
    public GameObject risingText;

    private GameMaster m_GameMaster;

    private void Start()
    {
        m_GameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_GameMaster.Heal();
            Destroy(gameObject);
            int score = 1000;
            GameMaster.score += (long)score;
            GameObject risingTextObject = Instantiate(risingText, transform.position, Quaternion.Euler(90f, 0f, 0f));
            risingTextObject.GetComponent<RisingScoreText>().StartRising(score, 1.5f, 8f);
        }
    }
}
