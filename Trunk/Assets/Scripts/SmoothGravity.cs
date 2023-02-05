using System.Collections;

using UnityEngine;

public class SmoothGravity : MonoBehaviour
{
    private float _verticalVelocity;
    [Tooltip("The height the player can jump")]
    public float JumpHeight = 1.2f;
    public bool windZoneStatus;

    public WindZone windZone;
    [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
    public float Gravity = -15.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetAxisRaw("Vertical")>0)
        {
            _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);

        }
    }
}
