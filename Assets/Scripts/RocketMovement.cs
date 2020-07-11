using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed = 100f;
    public Vector3 baseVelocity = Vector3.zero;

    private Rigidbody m_RigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = baseVelocity + transform.forward * speed;
        
        m_RigidBody.MovePosition(m_RigidBody.position + movement * Time.deltaTime);
        m_RigidBody.MoveRotation(m_RigidBody.rotation * Quaternion.Euler(0, 0, 10));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
