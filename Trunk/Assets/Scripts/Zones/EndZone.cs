
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    public string gameScene;
    private Scene scene;
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
        if (other.CompareTag("Player"))
         {
            SceneManager.LoadScene(gameScene);
           
            if (scene.name== "Park")
            {
                GameManager.instance.WinGame();
            }
        }
    }
}
