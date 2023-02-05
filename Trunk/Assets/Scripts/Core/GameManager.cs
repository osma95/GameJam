
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject pausedMenu;
    private Scene scene;
    string lobby = "Lobby";
    public GameObject gameOverPanel;
    public GameObject WinPanel;
    public TMP_Text gameOverText;
    public GameObject winPanel;
   public List<GameObject> gameOverObjects=new List<GameObject>() ;
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
        gameOverPanel.SetActive(false);
        WinPanel.SetActive(false);
    }
   public void MainMenuLoading()

    {  gameOverPanel.SetActive(false);
        pausedMenu.SetActive(false);
       // player= FindAnyObjectByType<MoveBehaviour>().gameObject;
      //  Destroy(player.gameObject);
       // LoadingScreen.instance.LoadLevel(lobby);
    }
    void Update()
    {
        if (scene.name != "Lobby") {   if (Input.GetKeyDown(KeyCode.Escape) && !pausedMenu.activeInHierarchy)
            {
                PausedGame(); Time.timeScale = 0;
               StarterAssetsInputs th = FindAnyObjectByType<StarterAssetsInputs>();
                th.cursorLocked = false;
                th.cursorInputForLook = false;
            }
            else
        if (Input.GetKeyDown(KeyCode.Escape) && pausedMenu.activeInHierarchy)
            {
              
                StarterAssetsInputs th = FindAnyObjectByType<StarterAssetsInputs>();
                th.cursorInputForLook = true;
                th.cursorLocked = true;
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
        winPanel.gameObject.SetActive(false);
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
      
        ActivateObjects();

    }
    public void ActivateObjects()
    {
        foreach (var obj in gameOverObjects)
            obj.SetActive(true);
    }
}
