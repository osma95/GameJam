using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StickUI : MonoBehaviour
{
    [SerializeField]

    Slider water_Slider;
    [SerializeField]

    Slider ground_Slider;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public  void UpgradeGroundSlider(float max,float value)
    {
        ground_Slider.minValue = 0;
        ground_Slider.maxValue = max;
        ground_Slider.value = value;



    }

    public void UpdateWaterSlider(float max,float value)
    {
        water_Slider.maxValue = max;
        water_Slider.value = value;
      
        water_Slider.minValue = 0;
    }

}
