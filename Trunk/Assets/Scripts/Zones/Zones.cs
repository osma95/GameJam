using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour
{

    public enum ZonesInteractive { WATER, GROUND, WINDZONE, FIRE }

    public ZonesInteractive zonesInteractive;
    bool canReg = true;



    Vector3 scale;
    public float ingredientForSecond = 2;
    void Start()
    {
        scale = new Vector3(-0.01f, -0.01f, -0.01f);
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

                        if (stickStats.StickWater < 100&& stickStats.IsRooted ) {


                        other.GetComponent<StickStats>().UpgradeWater(20 * Time.deltaTime);
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

                        if (stickStats.RoundNutrients < 100 && stickStats.IsRooted)
                        {


                            other.GetComponent<StickStats>().UpgradeGround(ingredientForSecond * Time.deltaTime);
                        }

                    }
                }


                break;

            case ZonesInteractive.FIRE:


                break;
        }
    }
}

    
     /*
        
    }

*/
