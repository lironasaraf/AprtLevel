using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayFunctionChatFisherMan : PlayFunctionChat
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fishingRod;
    [SerializeField] private GameObject boat;
    [SerializeField] private GameObject movementFishingRod;
    [SerializeField] private GameObject collectAllObjects;
    public override void playFunction()
    {
        if(collectAllObjects.transform.childCount > 0)
        {
            boat.GetComponent<PatrollerRegular>().enabled = true;
            player.transform.position = boat.transform.position;
            player.transform.parent = boat.transform;
            fishingRod.SetActive(true);
            movementFishingRod.SetActive(true);
        }
        else
        {
            collectAllObjects.GetComponent<ColletAllTheObjects>().enabled = true;
        }

    }

}
