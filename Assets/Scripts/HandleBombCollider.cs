using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBombCollider : MonoBehaviour
{
    public BombExplode bombExplode;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bombExplode.DoBomb();
            Destroy(gameObject);
        }
    }
}
