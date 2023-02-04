using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Vector2 sensibility;
    private new Transform camara;
    // Start is called before the first frame update
    void Start()
    {
        camara = transform.Find("Camera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0){
            transform.Rotate(Vector3.up * hor * sensibility.x);
        }

         if(ver != 0){
            camara.Rotate(Vector3.left * ver *sensibility.y);
        }

       
    }
}
