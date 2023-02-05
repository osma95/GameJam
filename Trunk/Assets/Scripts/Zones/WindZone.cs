using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{

  public float strength;
    public Vector3 direction;

    public bool isActive;

    public float timeWindWait =3;
    float timeWindCounter;

    public float timeActive=2;
    public float timeActiveCounter;
    void Start()
    {
        timeWindCounter = timeWindWait;
        timeActiveCounter= timeActive;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
          
            timeWindCounter-=Time.deltaTime;
          if (timeWindCounter <= 0)
            {
                isActive = true;
                timeWindCounter = timeWindWait;
            }
        }
        else
        {
            timeActiveCounter-=Time.deltaTime;
            if (timeActiveCounter<=0)
            {
                timeActiveCounter = timeActive;
                isActive = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<SmoothGravity>())
        {
                SmoothGravity sm=other.GetComponent<SmoothGravity>();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<TrunkMovement>() )
            {
                TrunkMovement tm = other.GetComponent<TrunkMovement>();
                tm.windZone = this;
               
                tm.windZone = null;


            }


        }
    }


       
}
