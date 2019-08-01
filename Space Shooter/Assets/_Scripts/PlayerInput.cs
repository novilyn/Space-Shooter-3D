using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Laser[] laser;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Laser l in laser)
            {
                //laser fire position 
                //Vector3 pos = transform.position + (transform.up * l.Distance);
               
                l.FireLaser();
                Debug.Log("fireLaser");

            
            }
                
        }
    }
}
