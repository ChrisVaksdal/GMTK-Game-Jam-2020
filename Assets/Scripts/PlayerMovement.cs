using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;
    public float friction = 1f;
    
    public ParticleSystem particleSystem;

    private Rigidbody m_RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float vertical = Mathf.Max(0, Input.GetAxis("Vertical"));
        float horizontal = Input.GetAxis("Horizontal");

        particleSystem.Stop();
        if (!Mathf.Approximately(vertical, 0))
        {
            particleSystem.Play();
        }
        
        Vector3 acceleration = Vector3.forward * (vertical * movementSpeed);
        
        m_RigidBody.AddRelativeForce(acceleration);
        Vector3 friction = m_RigidBody.velocity * (this.friction * -1);
        m_RigidBody.AddForce(friction);
        
        Vector3 eulerAngleVelocity = new Vector3(0, horizontal, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * (Time.deltaTime * rotationSpeed));
        m_RigidBody.MoveRotation(m_RigidBody.rotation * deltaRotation);
        
    }
}
