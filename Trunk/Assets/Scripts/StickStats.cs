using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickStats : MonoBehaviour
{
   float stickWater;

    float stickWaterMax=100;

   public int level;
    public float waterForSecond;
    public float StickWater =>stickWater;

  [SerializeField]   float groundNutrients;

    float groundNutrientMax = 100;

    public float RoundNutrients => groundNutrients;

    [SerializeField]StickUI stickUI;
    bool isRooted;
 

    public List<GameObject> stickModels = new List<GameObject>();   
    
    public bool IsRooted { get { return isRooted; } set { isRooted = value; } }
    void Start()
    {
       
        stickWater = stickWaterMax; UpgradeWater(stickWaterMax);
      
        UpgradeGround(0);
    }

    // Update is called once per frame
    void Update()
    {
     
        UpgradeWater(-waterForSecond * Time.deltaTime);
        levelUP();
        if (stickWater <= 0)
        {
            stickWater = 0;
            GameManager.instance.GameOverPanel("YOU LOSE YOU NEED MORE WATER");
        }
       
        if (isRooted)
        {
            
            stickUI.ActiveRootPanel();
            
        }
        else
        {
            stickUI.DesaRootPanel();
           
        }
    }
    void levelUP()
    {
        LevelUPStick();
        if (groundNutrients >= 100)
        {
            groundNutrients = 0;
            if(level!=3)
            level++;
        }
    }
    void LevelUPStick()
    {

<<<<<<< HEAD
       
=======

>>>>>>> e6bac8d789520d21dab5db19d3f78ca7d8c238ff
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
