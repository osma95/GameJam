using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    public string gameScene;
    private Scene scene;
    RootControl rt =null;
    void Start()
    {
        rt = FindAnyObjectByType<RootControl>();
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
         {
            LoadingScreen.instance.LoadLevel(gameScene);
            if (scene.name== "Rooftop")
            {
                StartCoroutine(WINGame());
              
            }
        }
    }

    IEnumerator WINGame()
    {
        rt.animator.SetBool("WIN", true);
        yield return new WaitForSeconds(1);

        GameManager.instance.WinGame();
    }
   
   
}
