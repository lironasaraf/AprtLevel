using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFunctionChatChild : PlayFunctionChat
{
    [SerializeField] private GameObject starChild;
    public override void playFunction()
    {
        Debug.Log("TalkWithChildDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
        starChild.SetActive(true);
        this.GetComponent<ChildThrowObjects>().enabled = false;
        this.GetComponent<EnemyController3>().enabled = false;
        this.GetComponent<Runner>().enabled = false;
        this.GetComponent<PatrollerRegular>().enabled = true;
    }
}
