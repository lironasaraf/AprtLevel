using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectObject : MonoBehaviour
{

    [SerializeField] private Transform hand;
    [SerializeField] Image HandImageCanvas;
    [SerializeField] TextMeshProUGUI HandTextCanvas;
    private Image emptyHand;
    private Sprite currentHand;
    private Vector3 lastPosition;
    private string typeObjectOnHand;

    private void Start()
    {
        emptyHand = HandImageCanvas;
    }



    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "pickup" && hand.childCount == 0)
        {
            lastPosition = collision.transform.position;
            collision.transform.parent = hand;
            collision.gameObject.SetActive(false);
            typeObjectOnHand = collision.gameObject.GetComponent<TypeObject>().getType();
            HandImageCanvas.sprite = collision.gameObject.GetComponent<TypeObject>().getSprite();
            currentHand = HandImageCanvas.sprite;
            HandTextCanvas.gameObject.SetActive(false);
        }
    }

    public Vector3 getLastPositionObject()
    {
        return lastPosition;
    }

    public string getTypeObjectOnHand()
    {
        return typeObjectOnHand;
    }

    public Sprite getEmptyHand()
    {
        return emptyHand.sprite;
    }

    public Sprite getCurrentHand()
    {
        return currentHand;
    }
}
