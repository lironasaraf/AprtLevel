using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI objectsGUI;
    [SerializeField] private GameObject objects;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        objectsGUI.text = "Object to collect: " + objects.transform.childCount;
    }
}
