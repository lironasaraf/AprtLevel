using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timeLeft;
    private float addTime;
    private bool takingAway;
    [SerializeField] private TextMeshProUGUI textCoins;
    // Start is called before the first frame update
    void Start()
    {
        takingAway = false;
        timerText.text = "Time: " + (timeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if(!OptionsGamePlay.menuIsActive)
        {
            if(!takingAway)
            {
                StartCoroutine(timerTaken());
            }
        }
        
    }

    IEnumerator timerTaken()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        if (timeLeft < 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            int coin = int.Parse(textCoins.text.Substring(7));
            PlayerPrefs.SetInt("coins", coin);
            SceneManager.LoadScene("MainGame");
        }
            
        timerText.text = "Time: " + (timeLeft + addTime);
        takingAway = false;
    }

    public void addTimeSkill(float addTime)
    {
        this.addTime += addTime;
    }
}