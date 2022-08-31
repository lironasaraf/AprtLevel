using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image purchasedImage;
    [SerializeField] private TextMeshProUGUI textSkill;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        purchasedItem();
    }

    // Update is called once per frame
    void Update()
    {
        purchasedItem();
    }

    private void purchasedItem()
    {
        //Debug.Log(PlayerPrefs.GetInt(textSkill.text));
        if(!purchasedImage.gameObject.activeSelf)
        {
            if (PlayerPrefs.GetString(textSkill.text).Equals("1"))
            {
                Debug.Log("INNNNNNNNNNNNNNNNNNNNNN");
                purchasedImage.gameObject.SetActive(true);
                button.interactable = false;
            }
            else
            {
                purchasedImage.gameObject.SetActive(false);
                button.interactable = true;
            }
        }
        
    }
}
