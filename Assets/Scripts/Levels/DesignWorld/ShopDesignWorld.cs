using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopDesignWorld : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceItem;
    private void Start()
    {
        int coinPriceItem = int.Parse(priceItem.text);
        if(PlayerPrefs.GetInt("coins") >= coinPriceItem)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
        
    }
}
