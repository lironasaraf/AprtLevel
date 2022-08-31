using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private CursorHider cursorHider;
    private void Awake()
    {
        cursorHider = new CursorHider();
        
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
        cursorHider.showCursor();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        cursorHider.hideCursor();
    }

}
