using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColletAllTheObjects : MonoBehaviour
{
    [SerializeField] private Transform theAllObjects;
    [SerializeField] private GameController gameController;
    [SerializeField] private Transform handPlayer;
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private bool saveGame;
    private int nextSceneIndex;
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (theAllObjects.childCount == 0 && handPlayer.childCount == 0)
        {
            //gameController.moveEndLevel();
            SceneManager.LoadScene("MainGame");
            if (saveGame)
            {
                if(PlayerPrefs.GetInt("levelAt") < nextSceneIndex)
                    PlayerPrefs.SetInt("levelAt", nextSceneIndex);
                int coin = int.Parse(textCoins.text.Substring(7));
                PlayerPrefs.SetInt("coins", coin);
            }    
            
        }
            
            
    }
}
