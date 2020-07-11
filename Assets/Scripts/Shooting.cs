using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;

    private Rigidbody m_PlayerRigidbody;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        m_PlayerRigidbody = player.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation);
            RocketMovement rocketMovement = instBullet.GetComponent<RocketMovement>();
            rocketMovement.baseVelocity = m_PlayerRigidbody.velocity;
        }
    }
}
