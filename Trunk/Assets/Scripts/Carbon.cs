using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carbon : MonoBehaviour
{
    public float energy;
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
            if (other.GetComponent<StickStats>())
            {
                other.GetComponent<StickStats>().UpgradeGround(energy);

                Destroy(gameObject);
            }
        }
    }
}
