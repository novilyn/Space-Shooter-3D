﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -5f);
    [SerializeField] float distanceDamp = 10f;


    Transform myT;

    public Vector3 velocity = Vector3.one;

    private void Awake()
    {
        myT = transform;
    }

    void LateUpdate()
    {
        if (!FindTarget())
            return;

        SmoothFollow();       
    }

    void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        myT.position = curPos;

        myT.LookAt(target, target.up);
    }

    bool FindTarget()
    {
        if (target == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");

            if (temp != null)
                target = temp.transform;
        }

        if (target == null)
            return false;
        return true;
    }
}
