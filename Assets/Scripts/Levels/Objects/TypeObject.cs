using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeObject : MonoBehaviour
{

    [SerializeField] string type;
    [SerializeField] Sprite imageObject;

    public string getType()
    {
        return type;
    }

    public Sprite getSprite()
    {
        return imageObject;
    }
}
