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
 [SerializeField]
    GameObject isRootedPanel;
  


    void Start()
    {
        DesaRootPanel();
       
    }
  

    // Update is called once per frame
    void Update()
    {
      
    }
    
    public void ActiveRootPanel()
    {
        isRootedPanel.SetActive(true);
    }
    public void DesaRootPanel()
    {
        isRootedPanel.SetActive(false);
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
