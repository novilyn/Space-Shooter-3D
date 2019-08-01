﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroids asteroid; 
    [SerializeField] int numberOfAsteroidsOnAxis = 10;
    [SerializeField] int gridSpacing = 100;

    void Start()
    {
 //       PlaceAsteroids();
    }

    void OnEnable()
    {
        EventManager.onStartGame += PlaceAsteroids;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= PlaceAsteroids;
    }

    void PlaceAsteroids()
    {
        for (int x = 0; x < numberOfAsteroidsOnAxis; x++)
        {
            for (int y = 0; y < numberOfAsteroidsOnAxis; y++)
            {
                for (int z = 0; z < numberOfAsteroidsOnAxis; z++)
                {
                    InstantiateAsteroid(x, 0, z);
                }
            }
                
        }
    }

    void InstantiateAsteroid(int x, int y, int z)
    {
        Instantiate(asteroid, new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(),
                                          transform.position.y + (y * gridSpacing) + AsteroidOffset(), 
                                          transform.position.z + (z * gridSpacing) + AsteroidOffset()), 
                                          Quaternion.identity, 
                                          transform);
    }

    float AsteroidOffset()
    {
        return Random.Range(gridSpacing / 2f, gridSpacing / 2f);
    }


}

