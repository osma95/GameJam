using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    public string gameScene;
   
    StickIdle stickIdle;
    StickStats stickStats;
    Vector3 scale;
    void Start()
    {
        stickIdle = FindAnyObjectByType<StickIdle>();
        stickStats = FindAnyObjectByType<StickStats>();

        scale = new Vector3(5, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
         {
            other.GetComponent<ThirdPersonController>().enabled = false;
            other.GetComponent<StickStats>().enabled = false;

            // stickStats.UpgradeGround(100);
            if (stickStats.RoundNutrients >= 100)
            {
                GameManager.instance.WinGame();
                GameManager.instance.winPanel.SetActive(true);
            }
           // if (stickIdle.transform.localScale != new Vector3 (2,2,2))
               
           stickIdle.trunks[4].transform.localScale += new Vector3(4f, 4f, 4) *Time.deltaTime;
                //StartCoroutine(WINGame());


        }
    }

    IEnumerator WINGame()
    {
       
        yield return new WaitForSeconds(1);

        GameManager.instance.WinGame();
    }
   
   
}
