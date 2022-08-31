using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{

    [SerializeField] private GameObject g;
    private bool isDropFishingRod;
    // Start is called before the first frame update
    void Start()
    {
        isDropFishingRod = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDropFishingRod && Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(dropFishingRod());
        }
        else if(isDropFishingRod && Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(raiseFishingRod());
        }
        if(g.transform.localScale.y < 1.0f && Input.GetKeyDown(KeyCode.E))
        {
            g.transform.localScale = new Vector3(g.transform.localScale.x, g.transform.localScale.y+0.1f, g.transform.localScale.z);
        }
        else if(g.transform.localScale.y > -1f && Input.GetKeyDown(KeyCode.Q))
        {
            g.transform.localScale = new Vector3(g.transform.localScale.x, g.transform.localScale.y - 0.1f, g.transform.localScale.z);
        }
    }

    IEnumerator dropFishingRod()
    {
        float scalex = g.transform.localScale.x;
        while (scalex < 1.0f)
        {
            yield return new WaitForSeconds(0.08f);
            g.transform.localScale = new Vector3(g.transform.localScale.x + 0.1f, g.transform.localScale.y, g.transform.localScale.z);
            scalex = g.transform.localScale.x;
        }
        isDropFishingRod = true;

    }

    IEnumerator raiseFishingRod()
    {
        float scalex = g.transform.localScale.x;
        while (scalex > 0f)
        {
            yield return new WaitForSeconds(0.08f);
            g.transform.localScale = new Vector3(g.transform.localScale.x - 0.1f, g.transform.localScale.y, g.transform.localScale.z);
            scalex = g.transform.localScale.x;
        }
        isDropFishingRod = false;

    }
}
