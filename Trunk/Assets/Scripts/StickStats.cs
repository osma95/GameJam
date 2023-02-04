using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickStats : MonoBehaviour
{
   float stickWater;

    float stickWaterMax=100;

   public int level;

    public float StickWater =>stickWater;

  [SerializeField]   float groundNutrients;

    float groundNutrientMax = 100;

    public float RoundNutrients => groundNutrients;

    StickUI stickUI;
    bool isRooted;
 

    public List<GameObject> stickModels = new List<GameObject>();   
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
        levelUP();
        if (stickWater <= 0)
        {
            stickWater = 0;
            GameManager.instance.GameOverPanel("YOU LOSE YOU NEED MORE WATER");
        }
        else
        {
           
            GameManager.instance.ClosedGameOverPanel();
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

        switch (level)
        {
            case 0:
                stickModels[0].gameObject.SetActive(true);
                stickModels[1].gameObject.SetActive(false);
                stickModels[2].gameObject.SetActive(false);
                break;

                case 1:
                stickModels[0].gameObject.SetActive(false);
                stickModels[1].gameObject.SetActive(true);
                stickModels[2].gameObject.SetActive(false);
                break;

            case 2:
                stickModels[0].gameObject.SetActive(false);
                stickModels[1].gameObject.SetActive(false);
                stickModels[2].gameObject.SetActive(true);
                break;
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
