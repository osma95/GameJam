using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickStats : MonoBehaviour
{

   public RootControl _rootControl;
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
     
        UpgradeWater(-waterForSecond * 20 * Time.deltaTime);
        levelUP();
        if (stickWater <= 0)
        {
            stickWater = 0;
            GameManager.instance.GameOverPanel("YOU LOSE YOU NEED MORE WATER");
        }
       
        if (isRooted)
        {
            _rootControl.animator.SetBool("Root", true);
            stickUI.ActiveRootPanel();
            
        }
        else
        {
            _rootControl.animator.SetBool("Root", false);
            stickUI.DesaRootPanel();
           
        }
    }
    void levelUP()
    {
       
    }
    void LevelUPStick()
    {


    }
    public void UpgradeWater(float newWater)
    {
        
        
        stickWater+=newWater;
        stickUI.UpdateWaterSlider(stickWaterMax,stickWater);
        if (stickWater >= stickWaterMax)
        {
          
            stickWater =stickWaterMax;
        }
        else
        {

        }

    }
    public void UpgradeGround(float newNutri)
    {

        if (groundNutrients >= 70) return;
       
        groundNutrients +=newNutri;
        stickUI.UpgradeGroundSlider(groundNutrientMax, groundNutrients);
        if (groundNutrients >= groundNutrientMax)
        {

           groundNutrients = groundNutrientMax;
        }

    }
}
