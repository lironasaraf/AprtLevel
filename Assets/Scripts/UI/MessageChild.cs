using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageChild : MonoBehaviour
{
    [SerializeField] private string[] messages;
    [SerializeField] private string[] titles;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI titleMessage;
    [SerializeField] private TextMeshProUGUI message;

    private int count;

    private void Start()
    {
        Debug.Log("shalom\n sss");
        count = 0;
        titleMessage.text = titles[count];
        message.text = messages[count++];
    }

    public void showMessage()
    {
        count = 0;
        titleMessage.text = titles[count];

        message.text = messages[count++];
       
    }

    public void nextMessage()
    {

        if (messages.Length <= count)
        {
            this.gameObject.SetActive(false);
            count = 0;
        }
        else
        {
            titleMessage.text = titles[count];
            message.text = messages[count++];
        }


    }

    public void exitMessage()
    {
        this.gameObject.SetActive(false);
        count = 0;
    }



}
