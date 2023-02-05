using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;
public class UIManager : MonoBehaviour
{

    public static UIManager instance;
  public  CinemachineVirtualCamera cinema;


    public GameObject creditPanel;
    public  GameObject tutorialPanel;
    public GameObject pausedMenu;

    public string gameScene;

     
    private void Awake()
    {
   
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
           
            instance = this;
        }
    }

  
    void Start()
    {
        ClosedAllPanel();
        
        
    }

    void ClosedAllPanel()
    {
        tutorialPanel.SetActive(false);
        creditPanel.SetActive(false);
       pausedMenu.SetActive(false);    

    }
    // Update is called once per frame
    void Update()
    {
        HotKeys();
    }
  

    public void StartGame()
    {
        ClosedAllPanel();
        LoadingScreen .instance.LoadLevel(gameScene);
      

    }
    public void OnCreditPanel()
    {
        creditPanel.SetActive(true);
    }
    public void DesCreditPanel()
    {
        creditPanel.SetActive(false);
    }
    public void TutorialPanel()
    {
        if (!tutorialPanel.activeInHierarchy)
        {
            cinema.gameObject.SetActive(true);
            tutorialPanel.gameObject.SetActive(true);
        }
        else if(tutorialPanel.activeInHierarchy)
        {
            cinema.gameObject.SetActive(false);
            tutorialPanel.gameObject.SetActive(false);
        }
      
    }
    public void ClosedTutorialPanel()
    {
        if (tutorialPanel.activeInHierarchy)
            {
            cinema.gameObject.SetActive(false);
            tutorialPanel.gameObject.SetActive(false);
        }
        else
        {
            tutorialPanel.gameObject.SetActive(true);
        }


        if (tutorialPanel.activeInHierarchy && Input.GetKey(KeyCode.Escape))
        {
            cinema.gameObject.SetActive(false);
            tutorialPanel.gameObject.SetActive(false);
        }
        else
        {
            tutorialPanel.gameObject.SetActive(true);
        }
    }
    public void OnClosedGame()
    {
        Application.Quit();
    }

    public void DesPausedGame()
    {


        pausedMenu.SetActive(false);
        Time.timeScale = 1;


    }
    public void PausedGame()
    {

        pausedMenu.SetActive(true);
        Time.timeScale = 0;


    }

    void HotKeys()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausedMenu.activeInHierarchy)
        {
           PausedGame();
        }
        else
       if (Input.GetKeyDown(KeyCode.Escape) && pausedMenu.activeInHierarchy)
        {
           DesPausedGame();
        }

      
       if (Input.GetKeyDown(KeyCode.T) )
        {
            TutorialPanel();
        }

        if (Input.GetKeyDown(KeyCode.C) && !creditPanel.activeInHierarchy)
        {
            OnCreditPanel();
        }
        else
       if (Input.GetKeyDown(KeyCode.C) && creditPanel.activeInHierarchy)
        {
            DesCreditPanel();
        }
    }
}
