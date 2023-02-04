using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour
{
    
    public  enum ZonesInteractive { WATER,GROUND,WINDZONE}

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
                        TrunkMovement trunk= other.GetComponent<TrunkMovement>();
                        if (stickStats.StickWater < 100&&trunk.IsRooted) {

                           
                            other.GetComponent<StickStats>().UpgradeWater(15 *Time.deltaTime);
                        }
                       
                    }
                }
                    break;

                case ZonesInteractive.GROUND:
                if (other.CompareTag("Player"))
                {

                    if (other.GetComponent<StickStats>())
                    {

                        StickStats stickStats = other.GetComponent<StickStats>();
                        TrunkMovement trunk = other.GetComponent<TrunkMovement>();
                        if (stickStats.RoundNutrients < 100 && trunk.IsRooted)
                        {
                           

                            other.GetComponent<StickStats>().UpgradeGround(5 * Time.deltaTime);
                        }

                    }
                }


                break;
        }
    }


   
}
