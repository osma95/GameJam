using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class CharacterPositionInit : MonoBehaviour
{
   public GameObject player;
    public Transform initPoint;
    void Start()
    {

        player.transform.position = initPoint.position;

       player.transform.rotation = initPoint.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
