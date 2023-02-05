using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickIdle : MonoBehaviour
{
   public StickStats stats;
 public   Animator anim;

    public List<GameObject> trunks = new List<GameObject>();

    void Start()
    {
        trunks[0].SetActive(true);
        trunks[1].SetActive(false);
        trunks[2].SetActive(false);
        trunks[3].SetActive(false);
        trunks[4].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.IsRooted)
        {
            anim.SetBool("Root", true);
        }
        else
        {
            anim.SetBool("Root", false);    
        }



        if ( stats.RoundNutrients >= 20)
        {

            trunks[0].SetActive(false);
            trunks[1].SetActive(true);
            trunks[2].SetActive(false);
            trunks[3].SetActive(false);
            trunks[4].SetActive(false);
        }

       
        if (stats.RoundNutrients >= 40)
            {

                trunks[0].SetActive(false);
                trunks[1].SetActive(false);
                trunks[2].SetActive(true);
                trunks[3].SetActive(false);
                trunks[4].SetActive(false);
            }
        if (stats.RoundNutrients >= 70)
        {

            trunks[0].SetActive(false);
            trunks[1].SetActive(false);
            trunks[2].SetActive(false);
            trunks[3].SetActive(true);
            trunks[4].SetActive(false);
        }
        if (stats.RoundNutrients >= 100)
        {

            trunks[0].SetActive(false);
            trunks[1].SetActive(false);
            trunks[2].SetActive(false);
            trunks[3].SetActive(false);
            trunks[4].SetActive(true);
        }
    }
}
