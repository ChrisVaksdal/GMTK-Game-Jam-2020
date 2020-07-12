using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HandleAsteroidCollision : MonoBehaviour
{
    public GameObject risingText;
    private ParticleSystem m_ParticleSystem;
    private GameMaster m_GameMaster;
    private AudioSource explodeAudio;

    void Start()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
        m_GameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        explodeAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_GameMaster.takeDamage();
            CinemachineShake.Instance.ShakeCamera(6f, 1f);
            Explode();
        }

        else if (other.CompareTag("Weapon"))
        {
            Destroy(other.gameObject);
            CinemachineShake.Instance.ShakeCamera(3f, 0.7f);
            Explode();
            int score = (int)Mathf.Floor(1000f / (float)transform.localScale.magnitude);
            GameMaster.score += (long)score;
            GameObject risingTextObject = Instantiate(risingText, transform.position, Quaternion.Euler(90f,0f,0f));
            risingTextObject.GetComponent<RisingScoreText>().StartRising(score, 1.5f, 8f);

        }
    }

    public void Explode()
    {
        m_ParticleSystem.Play();
        explodeAudio.Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, m_ParticleSystem.main.duration);
    }
}