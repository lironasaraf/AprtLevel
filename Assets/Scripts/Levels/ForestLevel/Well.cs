using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Well : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI showPressTextGUI;
    [SerializeField] private TextMeshProUGUI showTimeWaitTextGUI;
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private int timeWait;
    [SerializeField] private Shooter shooterPlayer;
    private void Start()
    {
        //shooterPlayer = GetComponent<Shooter>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(Input.GetKeyDown(keyCode))
            {
                StartCoroutine(timerTaken());
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        showPressTextGUI.gameObject.SetActive(true);
    }
    private void OnCollisionExit(Collision collision)
    {
        showPressTextGUI.gameObject.SetActive(false);
    }

    IEnumerator timerTaken()
    {
        int oldTimeWait = timeWait;
        showPressTextGUI.gameObject.SetActive(false);
        showTimeWaitTextGUI.gameObject.SetActive(true);
        for (int i = 0; i < timeWait; i++)
        {
            yield return new WaitForSeconds(1);
            timeWait -= 1;
            showTimeWaitTextGUI.text = "" + (timeWait);
        }
        shooterPlayer.Reload();
        timeWait = oldTimeWait;
        showTimeWaitTextGUI.gameObject.SetActive(false);
    }
}
