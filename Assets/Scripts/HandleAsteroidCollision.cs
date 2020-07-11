using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HandleAsteroidCollision : MonoBehaviour
{
    private ParticleSystem m_ParticleSystem;
    private GameMaster m_GameMaster;

    void Start()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
        m_GameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Aaaaa");
        if (other.CompareTag("Player"))
        {
            m_GameMaster.takeDamage();
            Explode();
        }

        else if (other.CompareTag("Weapon"))
        {
            Destroy(other.gameObject);
            Explode();
        }
    }

    private void Explode()
    {
        m_ParticleSystem.Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, m_ParticleSystem.main.duration);
    }
}