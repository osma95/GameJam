using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObj : MonoBehaviour
{
    public AudioSource playSound;
    int trigger = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "TriggerObj"){
            trigger = 1;
            playSound.Play();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "TriggerObj"){
            trigger = 0;
            playSound.Stop();
        }
    }
}
