using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private string worldScene;
    [SerializeField] private string tutorialScene;
    [SerializeField] private string multiPlayerScene;
    [SerializeField] private static float speedMouse;

    private void Start()
    {
        
            
    }
    public void moveEndLevel()
    {
        SceneManager.LoadScene(worldScene);
    }

    public void moveMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void moveExitGame()
    {
        Application.Quit();
    }

    public void moveNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }


    public void moveFirstLevel()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void moveTutorialScene()
    {
        SceneManager.LoadScene(tutorialScene);
    }

    public void moveMultiPlayerScene()
    {
        SceneManager.LoadScene(multiPlayerScene);
    }

    public void moveBackScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        
        
            SceneManager.LoadScene(nextSceneIndex);
        
    }







}
