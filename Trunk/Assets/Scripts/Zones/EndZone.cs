using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    public string gameScene;
   
    StickIdle stickIdle;
    StickStats stickStats;
    void Start()
    {
        stickIdle = FindAnyObjectByType<StickIdle>();
        stickStats = FindAnyObjectByType<StickStats>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
         {

            stickStats.UpgradeGround(100);
            if (stickIdle.transform.localScale != new Vector3 (2,2,2))
               
           stickIdle.trunks[4].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f) *Time.deltaTime;
                //StartCoroutine(WINGame());


        }
    }

    IEnumerator WINGame()
    {
       
        yield return new WaitForSeconds(1);

        GameManager.instance.WinGame();
    }
   
   
}
