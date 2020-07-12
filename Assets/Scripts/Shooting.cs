using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;

    private Rigidbody m_PlayerRigidbody;
    private GameMaster m_GameMaster;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        m_PlayerRigidbody = player.GetComponent<Rigidbody>();
        m_GameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_GameMaster.getPlayerHp() == 3)
        {
            CinemachineShake.Instance.ShakeCamera(2f, 0.3f);
            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation);
            RocketMovement rocketMovement = instBullet.GetComponent<RocketMovement>();
            rocketMovement.baseVelocity = m_PlayerRigidbody.velocity;
        }
    }
}
