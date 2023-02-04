using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public Button startButton;
    public TMP_Text startButtonText;
    public GameObject creditPanel;

    public GameObject pausedMenu;
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
        creditPanel.SetActive(false);
        pausedMenu.SetActive(false);    

    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        startButtonText.color = Color.white;

    }
    public void OnCreditPanel()
    {
        creditPanel.SetActive(true);
    }
    public void DesCreditPanel()
    {
        creditPanel.SetActive(false);
    }

    public void OnClosedGame()
    {
        Application.Quit();
    }
    public void PausedGame()
    {
        if (!pausedMenu.activeInHierarchy)
        {
            pausedMenu.SetActive(true);
            Time.timeScale = 0;

        }
            
    }
    public void ClosedPausedGame()
    {
        if (pausedMenu.activeInHierarchy)
        {
            Time.timeScale = 1;
            pausedMenu.SetActive(true);
        }
        
    }
}
