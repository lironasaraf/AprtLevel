using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("OptionsGamePlay").gameObject);
        Destroy(GameObject.Find("CanvasMenu").gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
