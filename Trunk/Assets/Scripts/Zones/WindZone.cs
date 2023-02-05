using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class WindZone : MonoBehaviour
{


  public float strength;

    public Animator animator;

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
                animator.SetBool("Wind", true);
                isActive = true;
                timeWindCounter = timeWindWait;
            }
        }
        else
        {
            timeActiveCounter-=Time.deltaTime;
            if (timeActiveCounter<=0)
            {
                animator.SetBool("Wind", false);
                timeActiveCounter = timeActive;
                isActive = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<ThirdPersonController>())
        {
               
 ThirdPersonController pr = other.GetComponent<ThirdPersonController>();
                pr.windZone = true;
                pr.inWindZone = this;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<ThirdPersonController>())
            {

                ThirdPersonController pr = other.GetComponent<ThirdPersonController>();
                pr.inWindZone = null;
                pr.windZone = false;
            }
        }
    }


       
}
