using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    
    public void DoBomb()
    {
        GameMaster.score += 2000;
        foreach (Transform child in transform)
        {
            try
            {

                child.gameObject.GetComponent<HandleAsteroidCollision>().Explode();
            }
            catch (Exception e)
            {
                // Do nothing
            }
        }
    }
}
