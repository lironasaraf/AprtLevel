using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button firstButton;
    [SerializeField] private Button lastButton;
    [SerializeField] private int index;
    [SerializeField] private int maxIndex;
    private bool keyDown;
    private AudioSource audioSource;
    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;

    }
    void Start()
    {
        firstButton.Select();
        audioSource = GetComponent<AudioSource>();
        
    }
    // disables button event call
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        firstButton.Select();
                        index = 0;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                        lastButton.Select();
                    }
                }
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }
    }
}
