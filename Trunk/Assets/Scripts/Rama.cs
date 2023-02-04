using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rama : MonoBehaviour
{

    private Rigidbody rama;


    // Start is called before the first frame update
    void Start(){
        rama = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Jump")){
            rama.AddForce(new Vector3(0,500,0));
        }
        
    }
}
