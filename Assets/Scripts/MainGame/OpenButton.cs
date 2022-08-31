using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    public void onClick_ShopButton(GameObject openGameObject)
    {
        openGameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
