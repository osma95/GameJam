using System.Collections;
using System.Collections.Generic;

using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class TrunkMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rigidbody;
    StickUI stickUI;
    [SerializeField]
    Camera _camera;
    public float distanceToCheck = 0.5f;
     bool isGrounded;

    public LayerMask groundLayer;
    public GameObject groundCheckGO;
    [SerializeField]
    Transform pivotA;

    [SerializeField]
    Transform pivotB;

    public bool windZoneStatus;

    public WindZone windZone;
    public
    float jumpForce;
   
    Vector3 dirMovement;
    public float speed;
    public enum MovementControl { TRUNK, THIRDPERSON }

    public MovementControl trunkControl;

    bool isRooted;
    public bool IsRooted { get { return isRooted; } set { isRooted = value; } }
    void Start()
    {
        stickUI = FindObjectOfType<StickUI>().GetComponent<StickUI>();
        _rigidbody = GetComponent<Rigidbody>();
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

                if (!isRooted)
                {
                    float horizontal = Input.GetAxis("Horizontal");

                    float vertical = Input.GetAxis("Vertical");


                    dirMovement.Set(horizontal, 0, vertical);
                    dirMovement.Normalize();

                    bool horizontalBool = !Mathf.Approximately(horizontal, 0);

                    bool verticalBool = !Mathf.Approximately(vertical, 0);

                    bool isWalking = horizontalBool || verticalBool;

                    Vector3 foward = Vector3.RotateTowards(transform.forward, dirMovement, 80 * Time.deltaTime, 0);
                    Quaternion rotation = Quaternion.LookRotation(foward);
                    _rigidbody.velocity = new Vector3(dirMovement.x, _rigidbody.velocity.y, dirMovement.z ) * speed;
                    _rigidbody.rotation = rotation;
                    stickUI.DesaRootPanel();
                    Jump();
                } else
                {

                    stickUI.ActiveRootPanel();
                }

                break;

        }
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheckGO.transform.position, Vector3.down, out hit, distanceToCheck, groundLayer))
        {
            isGrounded = true;
        }
       


        if (Input.GetKeyDown(KeyCode.R) && !isRooted)
        {
            isRooted = true;
        }
        else
        if (Input.GetKeyDown(KeyCode.R) && isRooted)
        {
            isRooted = false;
        }

        if (isRooted)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX;

        }
    

    }

   
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           // isGrounded = false;
        }
   
    }
    

}
