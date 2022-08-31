using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnHand : MonoBehaviour
{
    
    [SerializeField] private Image onHand;
    [SerializeField] private TextMeshProUGUI emptyTextHand;
    private Sprite oldSprite;
    private void Start()
    {
        oldSprite = onHand.sprite;
    }
    // Start is called before the first frame update

    public void setHand(Sprite sprite)
    {
        onHand.sprite = sprite;
        emptyTextHand.gameObject.SetActive(false);
    }

    public void setToDefault()
    {
        onHand.sprite = oldSprite;
        emptyTextHand.gameObject.SetActive(true);
    }
    
}
