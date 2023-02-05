using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialHelp : MonoBehaviour
{
    public GameObject panelNeedMana;
  public  TMP_Text textAlert;
    [TextArea]
  public  string waterText;

    [TextArea]
    public string ballDie;
    void Start()
    {
        panelNeedMana.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<StickStats>().UpgradeWater(-25);
    

            StartCoroutine(ActivePanel(waterText));
        }
    }

   public IEnumerator ActivePanel(string text)
    {
        textAlert.text = text;
        panelNeedMana.SetActive(true);
        yield return new WaitForSeconds(10); panelNeedMana.SetActive(false);
    }
    
}
