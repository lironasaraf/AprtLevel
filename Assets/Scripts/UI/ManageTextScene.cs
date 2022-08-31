using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageTextScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScene;
    [SerializeField] private Image _imageTextScene;
    [SerializeField] private float _timeTextScene;

    void Start()
    {
        StartCoroutine(timeTextScene());
    }



    private IEnumerator timeTextScene()
    {
        yield return new WaitForSeconds(_timeTextScene);
        _textScene.gameObject.SetActive(false);
        _imageTextScene.gameObject.SetActive(false);
    }


    public void getTextScene()
    {
        _textScene.gameObject.SetActive(true);
        _imageTextScene.gameObject.SetActive(true);
        StartCoroutine(timeTextScene());
    }

}
