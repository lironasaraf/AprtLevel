using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsRadiusFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.localPosition = player.transform.position;
    }
}
