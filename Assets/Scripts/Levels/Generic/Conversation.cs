using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    //[Tooltip("the messages in GUI for conversation")] [SerializeField] private GameObject messagesWithSomeone;
    [Tooltip("replay conversation with someone")] [SerializeField] private bool replayConversation;
    private int counter;
    Chat[] messages;

    
    // Start is called before the first frame update
    void Start()
    {
        messages = GetComponentsInChildren<Chat>(false);
        counter = 0;
    }



    public void conversation()
    {
        if(counter < messages.Length)
        {
            messages[counter++].transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            if (replayConversation)
                messages[counter-1].transform.GetChild(0).gameObject.SetActive(true);
            else
                counter = 0;
        }
    }
}
