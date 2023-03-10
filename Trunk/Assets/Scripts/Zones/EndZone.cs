using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class EndZone : MonoBehaviour
{
    public string gameScene;
    public GameObject TreeFinal;
    StickIdle stickIdle;
    StickStats stickStats;
    public GameObject cinema;
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
            other.gameObject.SetActive(false);
            // stickStats.UpgradeGround(100);

            
                GameManager.instance.WinGame();

            TreeFinal.gameObject.SetActive(true);
            GameManager.instance.WinGame();

                GameManager.instance.winPanel.SetActive(true);
            cinema.gameObject.SetActive(false);
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
