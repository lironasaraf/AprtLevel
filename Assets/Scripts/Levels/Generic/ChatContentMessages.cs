using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class ChatContentMessages
{


    [Tooltip("speaker NPC GameObject GUI")] [SerializeField] private GameObject speakerNPC;
    [Tooltip("speaker Player GameObject GUI")] [SerializeField] private GameObject speakerPlayer;
    //[SerializeField] private TextMeshProUGUI speakerName;
    [Tooltip("content message speaker")] [TextArea(3, 10)] [SerializeField] private string contentMessageSpeaker;
    [Tooltip("NPC speaker")] [SerializeField] private bool NPCTag = false;




    public string getContentMessageSpeaker()
    {
        return contentMessageSpeaker;
    }

    public void whoSpeaker()
    {
        if(NPCTag)
        {
            speakerNPC.SetActive(true);
            speakerPlayer.SetActive(false);
        }
        else
        {
            speakerNPC.SetActive(false);
            speakerPlayer.SetActive(true);
        }
    }

}
