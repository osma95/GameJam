using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5f;
    public float rotationspeed = 50f;
    // Update is called once per frame
    void Update()
    {
        float horizontalImput = Input.GetAxis("Horizontal");
        float vertialInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalImput,0, vertialInput);
        movementDirection.Normalize();

        transform.position= transform.position + movementDirection * speed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movementDirection),rotationspeed * Time.deltaTime);
    }
}


