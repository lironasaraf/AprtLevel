using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishCollisionObject : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "pickup")
        {
            //Destroy(collision.gameObject);
            //Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
