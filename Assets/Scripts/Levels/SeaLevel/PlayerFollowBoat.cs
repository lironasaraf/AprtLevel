using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowBoat : MonoBehaviour
{
    [SerializeField] private GameObject boat;

    private void Update()
    {
        this.transform.position += new Vector3(boat.transform.position.x, 0, boat.transform.position.z);
    }
}
