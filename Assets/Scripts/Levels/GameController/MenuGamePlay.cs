using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGamePlay : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    


    public void continueGame()
    {
        menu.gameObject.SetActive(false);
        OptionsGamePlay.menuIsActive = false;
    }

    public void menuGame()
    {
        SceneManager.LoadScene("MainMenu");
        menu.gameObject.SetActive(false);
        OptionsGamePlay.menuIsActive = false;
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
