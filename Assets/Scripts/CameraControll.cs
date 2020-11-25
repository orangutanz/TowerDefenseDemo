using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{    
    public float moveSpeed;
    public float zoomSpeed;


    private Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKey("q"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void Move()
    {
        Vector3 dir = new Vector3(0,0,0);
        Quaternion rot = transform.rotation;


        if (Input.GetKey(KeyCode.Space))
        {
            dir.y = 1;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dir.y = -1;
        }
        if (Input.GetKey("w"))
        {
            dir.z = 1;
        }
        if (Input.GetKey("s"))
        {
            dir.z = -1;
        }
        if (Input.GetKey("d"))
        {
            dir.x = 1;
        }
        if (Input.GetKey("a"))
        {
            dir.x = -1;
        }


        transform.position += dir * moveSpeed * Time.deltaTime;

    }


}
