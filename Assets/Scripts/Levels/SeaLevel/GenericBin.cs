using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericBin : MonoBehaviour
{
    [SerializeField] private GameObject genericBin;
    [SerializeField] private GameObject hand;
    private CollectObject collectObject;
    [SerializeField] private KeyCode dropToBinKey;
    [SerializeField] private KeyCode pollfromBinKey;
    [SerializeField] Image HandImageCanvas;
    private void Start()
    {
        collectObject = GetComponent<CollectObject>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "genericBin")
        {
            if(hand.transform.childCount != 0 && Input.GetKeyDown(dropToBinKey))
            {
                hand.transform.GetChild(0).parent = collision.transform;
                HandImageCanvas.sprite = null;
            }
            else if(collision.transform.childCount >= 0 && Input.GetKeyDown(pollfromBinKey) && hand.transform.childCount == 0)
            {
                collision.transform.GetChild(0).parent = hand.transform;
                collision.transform.GetChild(0).transform.position = collision.transform.position + Vector3.forward;
            }
        }
    }
}
