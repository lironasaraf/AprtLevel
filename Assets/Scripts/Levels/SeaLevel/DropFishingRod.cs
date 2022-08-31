using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFishingRod : MonoBehaviour
{
    //[SerializeField] private GameObject[] chooseObject;
    [SerializeField] GameObject sphere;
    [SerializeField] GameObject player;
    //[SerializeField] private GameObject images;
    [SerializeField] GameObject startPositionRod;
    [SerializeField] Material catchMaterial;
    [SerializeField] SphereCollider sphere1;
    [SerializeField] MeshCollider boat;
    private void Start()
    {
        
        sphere.transform.position = startPositionRod.transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "pickup")
        {
            Debug.Log("TRYCATCH");
            sphere.GetComponent<MeshRenderer>().material = catchMaterial;
        }
    }

    private void Update()
    {
        
            

        if(Input.GetKeyDown(KeyCode.I))
        {
            sphere.transform.position += player.transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            sphere.transform.position -= player.transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            sphere.transform.position += player.transform.right;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            sphere.transform.position -= player.transform.right;
        }









    }


}
