using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrototype;

    public float asteroidSpawnFrequency = 3f;       // Asteroids spawned pr. 10 seconds.
    public float spawnFrequencyAcc = 1.001f;        // How fast asteroid spawning will increase.
    public float maxAsteroidSpawnFrequency = 9f;   // Highest allowed spawnfrequency.

    public float asteroidMinScale = 0.3f;
    public float asteroidMaxScale = 1.8f;

    public float asteroidAccuracy = 1f;             // [0f-1f] Higher number --> Asteroids will aim closer to target.
    public float asteroidSpawnDistance = 10f;       // How far away asteroids will spawn.

    public float asteroidMinThrust = 0.4f;
    public float asteroidMaxThrust = 3f;


    private float timer = 0.0f;
    private float timeThreshold;




    /* Returns Vector3 at random angle with passed distance */
    private Vector3 getRandomSpawnPositionWithDistance(float distance)
    {
        float t = Random.Range(0, 360);
        return new Vector3(Mathf.Cos(t) * asteroidSpawnDistance, 0, Mathf.Sin(t) * asteroidSpawnDistance);
    }


    void Start()
    {
        timeThreshold = 10f / asteroidSpawnFrequency;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeThreshold)
        {
            /* Update spawnfrequency */
            if (asteroidSpawnFrequency * spawnFrequencyAcc <= maxAsteroidSpawnFrequency)
            {
                asteroidSpawnFrequency *= spawnFrequencyAcc;
            }


            /* Reset timer */
            timer = 0;
            timeThreshold = 10f / asteroidSpawnFrequency;        

            
            /* Create new asteroid */
            Vector3 newAsteroidPos = getRandomSpawnPositionWithDistance(asteroidSpawnDistance);
            GameObject newAsteroid = Object.Instantiate(asteroidPrototype, newAsteroidPos, Quaternion.identity, this.transform);


            /* Apply force to asteroid */
            Vector3 newAsteroidForceDirection = (this.transform.position - newAsteroidPos).normalized;
            newAsteroid.GetComponent<Rigidbody>().AddForce(newAsteroidForceDirection * Random.Range(asteroidMinThrust, asteroidMaxThrust) * 1000f);


            /* Scale, rotate and skew asteroid */
            newAsteroid.transform.localScale *= Random.Range(asteroidMinScale, asteroidMaxScale) * 10f;
            Vector3 pos = newAsteroid.transform.position;

            newAsteroid.transform.localRotation = Random.rotation;

            pos.x += Random.Range(-asteroidAccuracy, asteroidAccuracy) * asteroidMaxScale;
            pos.z += Random.Range(-asteroidAccuracy, asteroidAccuracy) * asteroidMaxScale;

            /* Add despawner to asteroid so it disappears when it goes of screen */
            newAsteroid.AddComponent<AsteroidDespawner>();
        }
    }
}
