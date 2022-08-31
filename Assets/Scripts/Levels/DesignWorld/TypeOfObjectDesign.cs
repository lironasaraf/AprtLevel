using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfObjectDesign : MonoBehaviour
{
    private bool ground;
    private bool wall;
    private string typeOfObjectDesign;
    

    private void Start()
    {
        if (ground)
            typeOfObjectDesign = "ground";
        else
            typeOfObjectDesign = "wall";
    }
}
