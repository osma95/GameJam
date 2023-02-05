using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrendets : MonoBehaviour
{
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<StickStats>())
            {
                other.GetComponent<StickStats>().UpgradeGround(20);
                Destroy(gameObject);
            }
        }
    }
}
