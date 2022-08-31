using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFunctionChatFisherManBoat : PlayFunctionChat
{
    [SerializeField] private GameObject boat;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fishingRod;
    [SerializeField] private GameObject movementFishingRod;
    [SerializeField] private Vector3 outFromBoat;
    public override void playFunction()
    {
        
        if(!boat.GetComponent<PatrollerRegular>().enabled)
        {
            player.transform.position = outFromBoat;
            player.transform.parent = null;
            fishingRod.SetActive(false);
            movementFishingRod.SetActive(false);
        }
            
    }
}
