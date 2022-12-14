using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button[] lvlButtons;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt",2);

        for(int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }

    }
}
