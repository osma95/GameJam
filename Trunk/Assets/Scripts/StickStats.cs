using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickStats : MonoBehaviour
{

   public RootControl _rootControl;
    float stickWater;
    public string sceneName;
    float stickWaterMax=100;
    private Scene scene;
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
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
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
            SceneManager.LoadScene(sceneName);
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

      
        groundNutrients +=newNutri;
        stickUI.UpgradeGroundSlider(groundNutrientMax, groundNutrients);
        if (groundNutrients >= groundNutrientMax)
        {

           groundNutrients = groundNutrientMax;
        }

    }
}
