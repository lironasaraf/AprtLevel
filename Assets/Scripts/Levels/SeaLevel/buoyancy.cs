using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buoyancy : MonoBehaviour
{
    [SerializeField]
    float buoyancy_force;
    Rigidbody rig;
    [Tooltip("sliding distance left and right")]
    [SerializeField] private float distance;
    [Tooltip("speed of the object")]
    [SerializeField] private float frequency;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        float y_pos = transform.position.y;
        if (y_pos < 0)
        {
            rig.AddForce(transform.up * buoyancy_force);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float y_pos = transform.position.y;
        if (y_pos < 0)
        {
            //rig.AddForce(transform.up * buoyancy_force);
            transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * frequency) * distance, transform.position.z);
        }
    }
}
