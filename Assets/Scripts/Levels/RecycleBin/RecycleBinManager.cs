using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBinManager
{
    // Start is called before the first frame update
    private static Vector3 openRecycleBinPosition;
    public void setOpenRecyclebinPosition(Vector3 openRecycleBinPosition1)
    {
        openRecycleBinPosition = openRecycleBinPosition1;
    }

    public Vector3 getOpenRecyclebinPosition()
    {
        return openRecycleBinPosition;
    }


}
