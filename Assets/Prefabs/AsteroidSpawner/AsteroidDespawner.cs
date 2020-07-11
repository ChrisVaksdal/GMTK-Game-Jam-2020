using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDespawner : MonoBehaviour
{
    private ParticleSystem m_ParticleSystem;

    private void Start()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
    }

    void OnBecameInvisible()
    {
        if (!m_ParticleSystem.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}