﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int curHealth;
    [SerializeField] int regenerateAmmount = 1;
    [SerializeField] float regenerationRate = 2f;


    private void Start()
    {
        curHealth = maxHealth;

        InvokeRepeating("Regenerate", regenerationRate,regenerationRate);
    }

    void Regenerate()
    {
        if(curHealth < maxHealth)
            curHealth += regenerateAmmount;

        if (curHealth > maxHealth)
            curHealth = maxHealth;
        // CancelInvoke();        

        EventManager.TakeDamage(curHealth / (float)maxHealth);
    }

    public void TakeDamage(int dmg = 1)
    {
        curHealth -= dmg;
        if (curHealth < 0)
            curHealth = 0;
        EventManager.TakeDamage(curHealth / (float)maxHealth);

        if(curHealth < 1)

            Debug.Log("Almost DEAD!");
           
    }
}