using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallDetec : MonoBehaviour
{
    private Scene scene;
    public string sceneName;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            TutorialHelp th =FindAnyObjectByType<TutorialHelp>();
            th.StartCoroutine(th.ActivePanel(th.ballDie));
        }
       
    }
}
