using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private Vector3 screenBounds;

    [SerializeField] float minScale = 0.8f;
    [SerializeField] float maxScale = 3.6f;
    [SerializeField] float rotationOffset = 100f;
    
   
    Transform trans;
    Vector3 randomRotation;

    void Awake()
    {
        trans = transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        //random size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);

        trans.localScale = scale;

        //random rotation
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
        

        //moving z direction
        rb = this.GetComponent<Rigidbody>();
       rb.velocity = new Vector3(0, 0, -speed);

    }

    // Update is called once per frame
    void Update()
    {
        trans.Rotate(randomRotation * Time.deltaTime);
    }

    

}

