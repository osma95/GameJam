using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject pausedMenu;
    private Scene scene;
    string lobby = "Lobby";
    public GameObject gameOverPanel;
    public GameObject WinPanel;
    public TMP_Text gameOverText;

    public GameObject player;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        pausedMenu.SetActive(false);
        ClosedGameOverPanel();
        WinPanel.SetActive(false);
    }
   public void MainMenuLoading()
    {
        pausedMenu.SetActive(false);
        player= FindAnyObjectByType<MoveBehaviour>().gameObject;
        Destroy(player.gameObject);
        LoadingScreen.instance.LoadLevel(lobby);
    }
    void Update()
    {
        if (scene.name != "Lobby") {   if (Input.GetKeyDown(KeyCode.Escape) && !pausedMenu.activeInHierarchy)
            {
                PausedGame(); Time.timeScale = 0;
            }
            else
        if (Input.GetKeyDown(KeyCode.Escape) && pausedMenu.activeInHierarchy)
            {
                DesPausedGame();
            }}
        
          

        
        



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
    public void GameOverPanel(string textGameOver)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = textGameOver;
        Time.timeScale = 0;
    }
    public void ClosedGameOverPanel()
    {
        gameOverPanel.SetActive(false);
     LoadingScreen.instance.LoadLevel(lobby);
        Time.timeScale = 1;
    }

    public void OnClosedGame()
    {
        Application.Quit();
    }

    public void WinGame()
    {
        WinPanel.SetActive(true);


    }
    public void ResetScene()
    {
        LoadingScreen.instance.LoadLevel(SceneManager.GetActiveScene().name );
    }
}
