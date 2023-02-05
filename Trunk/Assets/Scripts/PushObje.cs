using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObje : MonoBehaviour
{
    public float force;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rg = hit.collider.attachedRigidbody;
        if (rg != null)
        {
            Vector3 dir =hit.gameObject.transform.position;
            dir.y = 0;
            dir.Normalize();
            rg.AddForceAtPosition(dir * force, transform.position, ForceMode.Impulse);
        }
    }
}
