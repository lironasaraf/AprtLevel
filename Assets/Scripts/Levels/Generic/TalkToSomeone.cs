using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayFunctionChat))]
public class TalkToSomeone : MonoBehaviour
{
    [Tooltip("the our main player")] [SerializeField] private GameObject player;
    [Tooltip("the distance from player to start conversation")] [SerializeField] private float distance;
    [Tooltip("the text GUI that appear on the screen for press to conversation")] [SerializeField] private TextMeshProUGUI pressToTalkGUI;
    [Tooltip("the messages in GUI for conversation")] [SerializeField] private Conversation conversationWithSomeone;
    [Tooltip("the key for talk with someone")] [SerializeField] private KeyCode pressKey;
    //[Tooltip("replay conversation with someone")] [SerializeField] private bool replayConversation;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (distanceWithPlayer())
            conversation();

    }

    private void conversation()
    {
        if(pressToTalkGUI.enabled && Input.GetKeyDown(pressKey))
        {
            conversationWithSomeone.conversation();
        }
    }

    private bool distanceWithPlayer()
    {
        float dis = Vector3.Distance(player.transform.position, this.transform.position);
        if(dis <= distance)
        {
            pressToTalkGUI.enabled = true;
            return true;
        }
        else
        {
            pressToTalkGUI.enabled = false;
        }
 
        return false;
    }
}
