using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChildDistancePlayer : MonoBehaviour
{
    /*
    [Tooltip("the distance for talk with child")] [SerializeField] private float distanceFromChild;
    [Tooltip("star image of child")] [SerializeField] private GameObject starChild;
    [Tooltip("Press T text that appear")] [SerializeField] private TextMeshProUGUI textChildT;
    [Tooltip("MessagesWithChild in UI")] [SerializeField] private OpenedUI openedUI;
    [SerializeField] private GameObject player;
    private Chaser chaserChild;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        chaserChild = GetComponent<Chaser>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chaserChild.gameObject.activeSelf)
        {
            distance = Vector3.Distance(player.transform.position, this.transform.position);
            if (distance < distanceFromChild && !textChildT.gameObject.activeSelf)
            {
                textChildT.gameObject.SetActive(true);
            }
            else if(textChildT.gameObject.activeSelf && distance > distanceFromChild)
            {
                textChildT.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.T) && distance < distanceFromChild)
            {
                openedUI.openImageChild();
                starChild.gameObject.SetActive(true);
            }
        }
            
    }
    */
}
