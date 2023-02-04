using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour
{
    
    public  enum ZonesInteractive { WATER,GROUND,WINZONE}

    public ZonesInteractive zonesInteractive;
    bool canReg=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        switch (zonesInteractive)
        {
            case ZonesInteractive.WATER:

                if (other.CompareTag("Player"))
                {
                   
                    if (other.GetComponent<StickStats>())
                    {
                        
                        StickStats stickStats = other.GetComponent<StickStats>();
                        if (stickStats.StickWater < 100) {

                           
                            other.GetComponent<StickStats>().UpgradeWater(5 *Time.deltaTime);
                        }
                       
                    }
                }
                    break;

        }
    }


   
}
