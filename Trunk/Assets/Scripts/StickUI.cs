using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StickUI : MonoBehaviour
{
    [SerializeField]

    Slider water_Slider;


    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartWaterSlider()
    {
        water_Slider.minValue = 0;
        water_Slider.maxValue = 100;
        water_Slider.value = 100;

    }

    public void UpdateWaterSlider(float max,float value)
    {
        water_Slider.maxValue = max;
        water_Slider.value = value;
      
        water_Slider.minValue = 0;
    }

}
