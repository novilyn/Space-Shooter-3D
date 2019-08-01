using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] Thruster[] thruster;

    //Movement
    public float MoveSpeed = 10f;
    public float TurnRate = 2f;

    //Game
   // private int score = 0;
    
    private Camera playerCam;

    private void Start()
    {
        playerCam = GetComponentInChildren<Camera>();
//        Cursor.lockState = CursorLockMode.Locked;
        
    }
    private void Update ()
    {
        //ship Controller movement
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * MoveSpeed * Time.deltaTime, Space.Self);

        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X") * TurnRate, Input.GetAxisRaw("Mouse Y") * TurnRate);

        transform.Rotate(new Vector3(0f, md.x, 0f));
        playerCam.transform.Rotate(new Vector3(-md.y, 0f, 0f));
        playerCam.transform.rotation.eulerAngles.Set(0f, Mathf.Clamp(transform.rotation.eulerAngles.y, -90f, 90f), 0f);

        Thrust();
    }

    void Thrust()
    {
        if(Input.GetAxis("Vertical")>0)
        {
            foreach (Thruster t in thruster)
                t.Intensity(Input.GetAxis("Vertical"));
        }
        /*if (Input.GetKeyDown(KeyCode.W))
            foreach (Thruster t in thruster)
                t.Activate();
        else if (Input.GetKeyUp(KeyCode.W))
            foreach (Thruster t in thruster)
                t.Activate(false);*/
    }
}
