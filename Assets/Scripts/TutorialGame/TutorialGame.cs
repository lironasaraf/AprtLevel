using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGame : MonoBehaviour
{
    [SerializeField] private GameObject[] arrayTutorialObjects;
    [SerializeField] private GameObject[] arrayTutorialChildrens;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform handPlayer;
    private RecycleBinManager recycleBinManager;
    private bool arrowRecycleBin = false;
    private GameObject arrowRecycleBinObject;
    void Start()
    {
        recycleBinManager = new RecycleBinManager();

        
        //transform.position = arrayTutorialChild[0].transform.position+Vector3.up*2;
        //transform.parent = arrayTutorialChild[0].transform;
        for (int i = 0; i < arrayTutorialObjects.Length; i++)
        {
            GameObject newObject = Instantiate(prefab, arrayTutorialObjects[i].transform.position+Vector3.up*2, prefab.transform.rotation);
            newObject.transform.parent = arrayTutorialObjects[i].transform;
        }

        
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Arrow");
            //transform.position = arrayTutorialObjects[++_counter].transform.position + Vector3.up * 2;
            //transform.parent = arrayTutorialObjects[_counter].transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (handPlayer.childCount != 0 && !arrowRecycleBin)
        {
            Debug.Log("in");
            GameObject arrowRecycleBinObject1 = Instantiate(prefab, recycleBinManager.getOpenRecyclebinPosition() + Vector3.up * 5, prefab.transform.rotation);
            arrowRecycleBinObject = arrowRecycleBinObject1;
            //newObject.transform.parent = recycleBinManager.getOpenRecyclebinPosition();
            arrowRecycleBin = true;
        }
        else if(handPlayer.childCount == 0 && arrowRecycleBin)
        {
            Debug.Log("out");
            Destroy(arrowRecycleBinObject.gameObject);
            arrowRecycleBin = false;
        }

    }
    
}
