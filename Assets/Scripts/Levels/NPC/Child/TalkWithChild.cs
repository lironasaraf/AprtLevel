using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TalkWithChild : MonoBehaviour
{
    /*
    [SerializeField] private GameObject messagesWithChild;
    [SerializeField] private GameObject currentMessageChild;
    [SerializeField] private GameObject starChild;
    private ChildThrowObjects childThrowObjects;
    private NavMeshAgent navMeshAgent;
    private float lastSpeedMovement;
    private Chaser chaser;
    private bool startedTalk;
    private int count = 0;
    private int maxCount;
    // Start is called before the first frame update
    void Start()
    {
        chaser = GetComponent<Chaser>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        lastSpeedMovement = navMeshAgent.speed;
        childThrowObjects = GetComponent<ChildThrowObjects>();
        currentMessageChild = messagesWithChild.transform.GetChild(count).gameObject;
        maxCount = messagesWithChild.transform.childCount-1;
        Debug.Log(messagesWithChild.transform.GetChild(count).gameObject.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chaser.enabled)
        {
            if(starChild.activeSelf && currentMessageChild.activeSelf)
            {
                childThrowObjects.enabled = false;
                //chaser.enabled = false;
                Debug.Log("GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG");
                //lastSpeedMovement = navMeshAgent.speed;
                navMeshAgent.speed = 0;
                //startedTalk = true;
            }
            else if(starChild.activeSelf && !currentMessageChild.activeSelf)
            {
                //startedTalk = false;
                Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
                navMeshAgent.speed = lastSpeedMovement;
                if(count < maxCount)
                {
                    count++;
                    currentMessageChild = messagesWithChild.transform.GetChild(count).gameObject;
                }
                  
            }

        }
    }
    */
}
