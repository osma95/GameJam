using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("Asignar canciones para reproducir")]
    [Tooltip("Asignar canciones para reproducir")]
    [SerializeField]
    AudioSource[] audioTracks;

    public int currentTrack;
    [Header("Es para  activar el audio ")]
    [Tooltip("Es para  activar el audio")]
    [SerializeField] bool audioCanBePlayed;

    [SerializeField]
    List<AudioSource> uiSFX;

    bool AudioCanBePlayed => audioCanBePlayed;
    private void Awake()
    {
        MakeSingleton();
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
    void Update()
    {
        if (audioCanBePlayed)
        {
            if (!audioTracks[currentTrack].isPlaying)
            {
                audioTracks[currentTrack].Play();
            }
        }
        else
        {
            audioTracks[currentTrack].Stop();
        }
    }
    public void OnPlayUIMenuClick(int clickTrack)
    {
        uiSFX[clickTrack].Play();
    }

    /// <summary>
    /// Escoger una cancion por ID
    /// </summary>
    /// <param name="newTrack"></param>
    public void SetTrack(int newTrack)
    {
        audioTracks[currentTrack].Stop();
        currentTrack = newTrack;
        audioTracks[currentTrack].Play();
    }
    /// <summary>
    /// Cambia A la siguiente cancion o reinicia al 0
    /// </summary>
    public void NextSetTrack()
    {
        audioTracks[currentTrack].Stop();

        currentTrack++;

        if (currentTrack >= audioTracks.Length) currentTrack = 0;
        audioTracks[currentTrack].Play();




    }
    /// <summary>
    /// Cambia A la anterior cancion o reinicia al 0
    /// </summary>
    public void BackSetTrack()
    {
        audioTracks[currentTrack].Stop();
        currentTrack--;
        if (currentTrack < 0) currentTrack = audioTracks.Length - 1;

        audioTracks[currentTrack].Play();

    }
}