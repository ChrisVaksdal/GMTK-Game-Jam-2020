using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTurkeyCollision : MonoBehaviour
{
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
        }
    }
}
