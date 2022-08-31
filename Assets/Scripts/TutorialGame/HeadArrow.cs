using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadArrow : MonoBehaviour
{
    [SerializeField] private Transform hand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hand.childCount != 0)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
            
    }
}
