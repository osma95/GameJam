using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{

    public static LoadingScreen instance;

    [SerializeField] GameObject loadingBarHolder;
    [SerializeField] Image loadingBar;

    float progressValue = 0f;
    float progressMultiplier = 0.5f;
    float progressMultiplierEnd = 0.9f;
    private void Awake()
    {
        loadingBarHolder.SetActive(false);

        MakeSingleton();
    }
    private void Update()
    {
        ShowLoadingScreen();
    }
    void MakeSingleton()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    //para cambiar de escena y inicia el loading
    public void LoadLevel(string mapName)
    {

        // StartCoroutine(LoadAsyncLevel("Map0"));

        loadingBarHolder.SetActive(true);
        progressValue = 0f;
        Time.timeScale = 0f;
        SceneManager.LoadScene(mapName);
    }

    //se activa la imagen de carga si tiene el valor
    void ShowLoadingScreen()
    {
        if (progressValue < 1f)
        {
            progressValue += progressMultiplier * progressMultiplierEnd;
            loadingBar.fillAmount = progressValue;

            if (progressValue >= 1)
            {
                progressValue = 1.1f;
                loadingBar.fillAmount = 0f;
                loadingBarHolder.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    IEnumerator LoadAsyncLevel(string mapName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(mapName);
        loadingBarHolder.SetActive(true);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingBar.fillAmount = progress;

            if (progress >= 1f)
            {
                loadingBarHolder.SetActive(false);
            }
        }
        //devuelvo null para pasar al otro frame
        yield return null;
    }
}   