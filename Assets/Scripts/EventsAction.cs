using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventsAction : MonoBehaviour
{


    [SerializeField] GameObject[] furniture;
    private bool[] flags= { false, false, false, false };
    private bool[] stateOf = { false, false, false, false };
    [SerializeField] GameObject timerManger;
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private Material black;
    [SerializeField] private Material TVMat;
    [SerializeField] private Material LampMat;
    private int points = 0;
    [SerializeField] private float randTime;
    private bool flagRand=true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            if (flags[0] && !stateOf[0]) {
                stateOf[0] = true;
                points++;
                furniture[0].transform.GetChild(1).GetComponent<MeshRenderer>().material = black;
                textCoins.text = "Coints: " + points;
                awakeStateOf(0);
            }
            else if (flags[1] && !stateOf[1]) {
                stateOf[1] = true;
                points++;
                furniture[1].SetActive(false);
                textCoins.text = "Coints: " + points;
                awakeStateOf(1);
            }
            else if (flags[2] && !stateOf[2]) {
                stateOf[2] = true;
                points++;
                furniture[2].SetActive(false);
                textCoins.text = "Coints: " + points;
                awakeStateOf(2);
            }
            else if (flags[3] && !stateOf[3]) {
                stateOf[3] = true;
                points++;
                furniture[3].transform.GetChild(3).GetComponent<MeshRenderer>().material = black;
                textCoins.text = "Coints: " + points;
                awakeStateOf(3);
            }
        }
    }

    private void awakeStateOf(int num)
    {
 
                StartCoroutine(waitSec(randTime, num));
    }

    private IEnumerator waitSec(float n,int r) {
        yield return new WaitForSeconds(n);
        if (r == 0)
        {
            stateOf[0] = false;
            furniture[0].transform.GetChild(1).GetComponent<MeshRenderer>().material = TVMat;

        }
        else if (r == 3)
        {
            stateOf[3] = false;
            furniture[3].transform.GetChild(3).GetComponent<MeshRenderer>().material = LampMat;


        }
        else
        {
            stateOf[r] = false;
            furniture[r].SetActive(true);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TV")
        {
            StartCoroutine(massage("Please press T to turn off the TV!", 0));

        }
        else if (other.tag == "Fire")
        {
            StartCoroutine(massage("Please press T to turn off the gas!", 1));
        }
        else if (other.tag == "Water")
        {
            StartCoroutine(massage("You are wasting water! Please press T to turn off the water!", 2));
        }
        else if (other.tag == "Lamp")
        {
            StartCoroutine(massage("The lamp is lighting with no reason! Please press T to turn off the TV!", 3));
        }


        //Destroy(this.gameObject);

    }

    IEnumerator massage(string str, int i)
    {
        mainText.text = str;
        flags[i] = true;
        yield return new WaitForSeconds(4f);
        flags[i] = false;
        mainText.text = "";
    }

}
