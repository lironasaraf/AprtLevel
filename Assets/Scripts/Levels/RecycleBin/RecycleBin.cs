using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecycleBin : MonoBehaviour
{
    [Tooltip("open the recyclebin")] [SerializeField] private bool isOpen;
    [SerializeField] private string type;

    //[Tooltip("")] [SerializeField] private GameObject hisObject;





    public bool getOpen()
    {
        return isOpen;
    }

    public void setOpen(bool open)
    {
        this.isOpen = open;
    }


    public string getType()
    {
        return type;
    }
    



    private void Update()
    {
       
    }

}
