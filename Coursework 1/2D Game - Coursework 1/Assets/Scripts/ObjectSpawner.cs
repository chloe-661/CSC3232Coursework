using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    //Randomly makes interactable objects fall into the level at random locations
    //Such as health potions to revive health, or coins to increase score, etc

    public GameObject healthPotionPrefab, coinPrefab;
    private float spawnRate;
    private float nextSpawn;
    private int type;

    void Start()
    {
        spawnRate = 2f;
        nextSpawn = 0f;
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            type = Random.Range(0, 3);
            float x = Random.Range(-40, 255);
            float y = Random.Range(10, 60);
            Vector3 newPosition = new Vector3(x, y, 0);

            switch (type)
            {
                case 0:
                    Instantiate(healthPotionPrefab, newPosition, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(coinPrefab, newPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(coinPrefab, newPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(coinPrefab, newPosition, Quaternion.identity);
                    break;
            }
            spawnRate = Random.Range(0, 20);
            nextSpawn = Time.time + spawnRate;
        }
    }
}
