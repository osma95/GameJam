using System.Collections;
using System.Collections.Generic;

using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class TrunkMovement : MonoBehaviour
{


    [SerializeField]
    Transform pivotA;

    [SerializeField]
    Transform pivotB;

  
    
    [SerializeField]
    Rigidbody _rigidbody;

    [SerializeField]
    Camera _camera;
    
   
    Vector3 dirMovement;
   public float speed;
   public enum MovementControl { TRUNK, THIRDPERSON}

    public MovementControl trunkControl;
    void Start()
    {
        _rigidbody =GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        switch (trunkControl)
        {

            case MovementControl.TRUNK:
                if (Input.GetKey(KeyCode.W) && Vector3.Distance(pivotA.forward, -_camera.transform.forward) > 0.3f)
                {
                    
                   // transform.RotateAround(pivotA.transform.position, _camera.transform.right, 180 * Time.deltaTime);
              

                }
                else if (Input.GetKey(KeyCode.S) && Vector3.Distance(pivotB.forward, -_camera.transform.forward) > 0.3f)
                {
                  
                   // transform.RotateAround(pivotB.transform.position, _camera.transform.right, 180 * Time.deltaTime);
                }


                break;

            case MovementControl.THIRDPERSON:

                float horizontal = Input.GetAxis("Horizontal");

                float vertical = Input.GetAxis("Vertical");

                dirMovement.Set(horizontal, 0, vertical);
                dirMovement.Normalize();

                bool horizontalBool = !Mathf.Approximately(horizontal, 0);

                bool verticalBool = !Mathf.Approximately(vertical, 0);

                bool isWalking = horizontalBool || verticalBool;

                Vector3 foward = Vector3.RotateTowards(transform.forward, dirMovement, 80 * Time.deltaTime, 0);
                Quaternion rotation = Quaternion.LookRotation(foward);
                _rigidbody.MovePosition(_rigidbody.position + dirMovement * speed * Time.deltaTime);
                break;

        }
    }
    void Update()
    {

       
       

      


    }

}
