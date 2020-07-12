using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBombCollider : MonoBehaviour
{
    public BombExplode bombExplode;
    public GameObject risingText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bombExplode.DoBomb();
            Destroy(gameObject);
            int score = 2500;
            GameMaster.score += (long)score;
            GameObject risingTextObject = Instantiate(risingText, transform.position, Quaternion.Euler(90f, 0f, 0f));
            risingTextObject.GetComponent<RisingScoreText>().StartRising(score, 1.5f, 8f);
        }
    }
}
