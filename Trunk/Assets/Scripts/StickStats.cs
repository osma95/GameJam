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
    void Start()
    {
        stickUI = FindObjectOfType<StickUI>().GetComponent<StickUI>();
        stickWater = stickWaterMax; UpgradeWater(stickWaterMax);

        UpgradeGround(0);
    }

    // Update is called once per frame
    void Update()
    {
     
        UpgradeWater(-8f * Time.deltaTime);

        if (stickWater <= 0)
        {
            stickWater = 0;
            GameManager.instance.GameOverPanel("YOU LOSE YOU NEED MORE WATER");
        }
        else
        {
            GameManager.instance.ClosedGameOverPanel();
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
