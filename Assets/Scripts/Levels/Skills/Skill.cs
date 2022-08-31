using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] private KeyCode keyCodeSkill;
    [SerializeField] private string skill;
    [SerializeField] private Skills skills;

    private void Update()
    {
        if (Input.GetKeyDown(keyCodeSkill) && PlayerPrefs.GetString(skill).Equals("1"))
        {
            skills.selectSkill(skill);
            gameObject.SetActive(false);
        }
    }
  
}
