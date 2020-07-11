using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDespawner : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
