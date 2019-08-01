using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timePassed;
    bool keepTime = false;

    void onEnable()
    {
        EventManager.onStartGame += StartTimer;
        EventManager.onStartGame += StopTimer;
    }

    void onDisable()
    {
        EventManager.onStartGame -= StartTimer;
        EventManager.onStartGame -= StopTimer;
    }

    void Update()
    {
        if (keepTime)
        {
            timePassed += Time.deltaTime;
        }
    }

    void StartTimer()
    {
        timePassed = 0;
        keepTime = true;
    }

    void StopTimer()
    {
        keepTime = false;
    }

    void UpdateTimerDisplay()
    {

    }
}
