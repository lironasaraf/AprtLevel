using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePickUp : MonoBehaviour
{

    [SerializeField] private Sprite sprite;
    private OnHand onHand;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && (this.gameObject.transform.parent == null || !this.gameObject.transform.parent.name.Equals("hand")))
        {
            Debug.Log("PLAYERRRRRRRRRRRRRRRRRRRRRR");
            StartCoroutine(CoolDownRoutine());
        }
    }

    IEnumerator CoolDownRoutine()
    {
        yield return new WaitForSeconds(0.3f);
        onHand = this.gameObject.transform.parent.GetComponent<OnHand>();
        onHand.setHand(sprite);
    }

    private void OnDestroy()
    {
        onHand.setToDefault();
    }
}
