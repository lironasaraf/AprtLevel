using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOff : MonoBehaviour
{
    [SerializeField] private GameObject handPlayer;
    [SerializeField] private int lives;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    
    private void Start()
    {
        lives *= 2;
        if(slider != null)
        {
            slider.maxValue = lives;
            slider.value = lives;
            fill.color = gradient.Evaluate(1f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "Ballet")
        {
            if (lives <= 0)
                Destroy(this.gameObject);
            slider.value = lives;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            lives -= 1;
            Debug.Log("INNNNNNNNNNNNNNNNNNNNN-1");
        }
    }
}
