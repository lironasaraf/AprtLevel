using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoSensitivityMouse : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image img1;
    [SerializeField] private Image img2;
    [SerializeField] private TextMeshProUGUI text;
    public static float time = 0;
    [SerializeField] private GameObject[] positionRedBall;
    public static float speedSesitivity = 0;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }



    public void dragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out pos);

        transform.position = canvas.transform.TransformPoint(pos);
        time += Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("UUUUUUUUUUUUUUUUUUUUUUUUUUU");  // Or whatever function you want
        Debug.Log("Time: " + time);
        speedSesitivity += time;
        if (count > positionRedBall.Length-1)
        {
            img1.gameObject.SetActive(false);
            img2.gameObject.SetActive(false);
            speedSesitivity /= (positionRedBall.Length+1);
            text.gameObject.SetActive(true);
            text.text += " your mouse speed is: " + speedSesitivity;
        }
        else
        {
            img2.transform.position = positionRedBall[count].transform.position;
            count++;
            time = 0;
        }

    }






}
