using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] private TimerGame timer;
    [SerializeField] private SimpleSampleCharacterControl playerMovement;
    public void selectSkill(string skill)
    {
        switch (skill)
        {
            case "Timer":
                timerSkill(skill);
                break;
            case "Speed":
                speedSkill(skill);
                break;

        }
    }


    private void timerSkill(string skill)
    {
        timer.addTimeSkill(30);
        Debug.Log("Timer getting: " + PlayerPrefs.GetString(skill));
        PlayerPrefs.SetString(skill, "0");
    }

    private void speedSkill(string skill)
    {
        StartCoroutine(timeSpeedSkill());
        Debug.Log("Speed getting: " + PlayerPrefs.GetString(skill));
        PlayerPrefs.SetString(skill, "0");
    }

    IEnumerator timeSpeedSkill()
    {
        playerMovement.increaseSpeedSkill(1.5f);
        yield return new WaitForSeconds(10);
        playerMovement.increaseSpeedSkill(1f);
    }




}
