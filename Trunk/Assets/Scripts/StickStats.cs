using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickStats : MonoBehaviour
{
   float stickWater;

    float stickWaterMax=100;

    public float StickWater =>stickWater;

     float groundNutrients;

    float groundNutrientMax = 100;

    public float RoundNutrients => groundNutrients;

    StickUI stickUI;
    bool isRooted;
    [SerializeField]
    GameObject rootPanel;
   Rigidbody rb;
    public bool IsRooted { get { return isRooted; } set { isRooted = value; } }
    void Start()
    {
        stickUI = FindObjectOfType<StickUI>().GetComponent<StickUI>();
        stickWater = stickWaterMax; UpgradeWater(stickWaterMax);
        rb = GetComponent<Rigidbody>();
        UpgradeGround(0);
    }

    // Update is called once per frame
    void Update()
    {
     
        UpgradeWater(-0.25f * Time.deltaTime);

        if (stickWater <= 0)
        {
            stickWater = 0;
           // GameManager.instance.GameOverPanel("YOU LOSE YOU NEED MORE WATER");
        }
        else
        {
           
          //  GameManager.instance.ClosedGameOverPanel();
        }
        if (isRooted)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            stickUI.ActiveRootPanel();
            rb.velocity = Vector3.zero;
        }
        else
        {
            stickUI.DesaRootPanel();
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            rb.constraints = RigidbodyConstraints.FreezeRotationX;
        }
    }

    public void UpgradeWater(float newWater)
    {
        

        stickWater+=newWater;
        stickUI.UpdateWaterSlider(stickWaterMax,stickWater);
        if (stickWater >= stickWaterMax)
        {
          
            stickWater =stickWaterMax;
        }

    }
    public void UpgradeGround(float newNutri)
    {


        groundNutrients +=newNutri;
        stickUI.UpgradeGroundSlider(groundNutrientMax, groundNutrients);
        if (groundNutrients >= groundNutrientMax)
        {

           groundNutrients = groundNutrientMax;
        }

    }
}
