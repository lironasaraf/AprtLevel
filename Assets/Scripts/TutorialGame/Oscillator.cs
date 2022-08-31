using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [Tooltip("sliding distance left and right")]
    [SerializeField] private float distance;
    [Tooltip("speed of the object")]
    [SerializeField] private float frequency;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("deltaTime: " + new Vector3(Mathf.Sin(Time.time), 0, 0));
        transform.position = new Vector3(transform.position.x, Mathf.Abs(transform.position.y + (Mathf.Cos(Time.time * frequency) * distance)), transform.position.z);
    }
}
