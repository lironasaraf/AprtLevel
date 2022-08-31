using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myCoins;

    private bool boughtItem;
    private void Start()
    {
        myCoins.text = PlayerPrefs.GetInt("coins") + "";
    }
    public void buyItem(TextMeshProUGUI priceItemText)
    {
        int priceItem = int.Parse(priceItemText.text);
        if(PlayerPrefs.GetInt("coins") >= priceItem)
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - priceItem);
            boughtItem = true;
            myCoins.text = PlayerPrefs.GetInt("coins") + "";
        }
    }

    public void saveItem(TextMeshProUGUI titleItemText)
    {
        if(boughtItem)
        {
            PlayerPrefs.SetString(titleItemText.text, "1");
            boughtItem = false;
        }
            
    }
}
