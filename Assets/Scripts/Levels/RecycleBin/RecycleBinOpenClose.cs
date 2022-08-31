using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecycleBinOpenClose : MonoBehaviour
{
    [SerializeField] private RecycleBin[] recycleBins;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform allObjects;
    [SerializeField] TextMeshProUGUI HandTextCanvas;
    [SerializeField] private TextMeshProUGUI textWrongBin;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] Image HandImageCanvas;
    private CollectObject collectObject;
    
    private Sprite lastImageCanvas;

    private RecycleBinManager recycleBinManager;

    private void Start()
    {
        recycleBinManager = new RecycleBinManager();
        collectObject = GetComponent<CollectObject>();
        lastImageCanvas = HandImageCanvas.sprite;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pickup" && hand.childCount == 0)
        {
            for (int i = 0; i < recycleBins.Length; i++)
            {
                if (collision.gameObject.GetComponent<TypeObject>() != null)
                {
                    if (recycleBins[i].getType().Equals(collision.gameObject.GetComponent<TypeObject>().getType()))
                    {
                        recycleBins[i].setOpen(true);
                        recycleBinManager.setOpenRecyclebinPosition(recycleBins[i].transform.position);
                        Debug.Log(recycleBinManager.getOpenRecyclebinPosition());
                    }
                }
                else
                {
                    Debug.Log("need to put TypeObject");
                }


            }

        }
        
        if (collision.gameObject.tag == "recyclebin" && hand.childCount != 0)
        {
            HandTextCanvas.gameObject.SetActive(true);
            HandImageCanvas.sprite = lastImageCanvas;
            if (collision.gameObject.GetComponent<RecycleBin>().getOpen())
            {
                Destroy(hand.GetChild(0).gameObject);
                //addPoint();
                audioManager.successBin();
                collision.gameObject.GetComponent<RecycleBin>().setOpen(false);
            }
            else
            {
                audioManager.failedBin();
                GameObject g = hand.GetChild(0).gameObject;
                hand.GetChild(0).transform.parent = null;
                g.transform.position = collectObject.getLastPositionObject();
                g.transform.parent = allObjects;
                for (int i = 0; i < recycleBins.Length; i++)
                {
                    recycleBins[i].setOpen(false);
                }

                StartCoroutine(failBin());
            }





        }

    }

    private IEnumerator failBin()
    {
        textWrongBin.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        textWrongBin.gameObject.SetActive(false);
    }

}
