using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignWorld : MonoBehaviour
{
    //[SerializeField] private GameObject[] chooseObject;
    private GameObject currentObject;
    [SerializeField] GameObject[] ObjectsToPutOn;
    //[SerializeField] private GameObject images;
    [SerializeField] private GameObject environment;
    private Color lastColorObject;
    public void putTree(GameObject prefab)
    {

        currentObject = Instantiate(prefab);
        //lastColorObject = ObjectsToPutOn[0].GetComponent<MeshRenderer>().material.color;

        currentObject.transform.Rotate(new Vector3(90, 0));
        //images.SetActive(false);
        
        
    }
    private void Update()
    {
        if(currentObject != null)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            
          

            if (ObjectsToPutOn[0].GetComponent<Collider>().Raycast(castPoint, out hit, Mathf.Infinity))
            {
                currentObject.transform.position = hit.point;
                //currentObject.GetComponent<MeshRenderer>().material.color = Color.red;
                //ObjectsToPutOn[0].GetComponent<MeshRenderer>().material.color = Color.green;
                if (Input.GetMouseButtonDown(0))
               {
                    currentObject.transform.parent = environment.transform;
                    currentObject = null;
                    //ObjectsToPutOn[0].GetComponent<MeshRenderer>().material.color = lastColorObject;
                }
               else if(Input.GetMouseButtonDown(1))
               {
                    Destroy(currentObject.gameObject);
                    //images.SetActive(true);
                    //ObjectsToPutOn[0].GetComponent<MeshRenderer>().material.color = lastColorObject;
                }
                
            }
                    

            

           



         
        }
            
    }
}
