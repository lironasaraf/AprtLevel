using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenedUI : MonoBehaviour
{
    [Tooltip("array of messages with child")] [SerializeField] private Image[] imageChild;
    private int count;
    private void Awake()
    {
        //Debug.Log("Found before " + imageChild.Length + " active images.");
        imageChild = this.transform.GetComponentsInChildren<Image>(true);
        //Debug.Log("Found after " + imageChild.Length + " active images.");
    }
    private void Start()
    {
        
        count = 0;
    }



    public void openImageChild()
    {
        imageChild[count].gameObject.SetActive(true);
        addToCount();
        
    }

    private void addToCount()
    {
        if(count+3 < imageChild.Length)
            count+=3;
    }
}
