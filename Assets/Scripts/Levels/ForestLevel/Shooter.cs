using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Tooltip("Particle-effect that is triggered near the weapon mouth when the player shoots")]
    [SerializeField] private GameObject muzzleFlash = null;

    [Tooltip("Particle-effect that is triggered where the player's bullet hits")]
    [SerializeField] private GameObject bulletHole = null;

    [Tooltip("How many bullets the player initially has")]
    [SerializeField] private int startAmmo = 50;

    [Tooltip("How many bullets the player currently has")]
    [SerializeField] private int ammo;

    private Vector3 saveLocation;

    [SerializeField] private Transform hand;

    [SerializeField] private GameObject weapon;

    [SerializeField] private TextMeshProUGUI ammoText;


    private bool isShot = true;

    void Start()
    {
        ammo = startAmmo;
        ammoText.text = "Ammo: " + ammo;
        muzzleFlash.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && weapon.transform.parent != null)
        {
            if (ammo > 0 && isShot)
            {
                Shoot();
                ammoText.text = "Ammo: " + ammo;
                StartCoroutine(ShootingCoolDownRoutine());
            }
            else
            {
                Debug.Log("Out of ammunition!");
            }
        }
        //if (Input.GetKeyDown(KeyCode.R) && !_isReloading)
        //{
            //_isReloading = true;
            //Reload();
        //}

        if (Input.GetKeyDown(KeyCode.Z) && weapon.transform.parent != null)
        {
            weapon.transform.parent = null;
            Destroy(weapon.gameObject);

        }



    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Weapon" && weapon.transform.parent == null)
        {
            Debug.Log("Weapon");
            
            other.transform.parent = hand;
            other.transform.position = hand.position;
            other.transform.rotation = hand.rotation;
            weapon = other.gameObject;
        }



    }

    private void Shoot()
    {
        muzzleFlash.SetActive(true);
        StartCoroutine(StopEffect());
        //Debug.Log("Shooting");

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            GameObject hitMarker = Instantiate(bulletHole, hitInfo.point, Quaternion.identity);
            Destroy(hitMarker, 1f);
            if (hitInfo.collider.tag == "Enemy")
            {
                saveLocation = hitInfo.transform.position;
                Destroy(hitInfo.collider.gameObject);
                Instantiate(weapon.gameObject, saveLocation, Quaternion.identity);
                Debug.Log("Enemy is hit! You win!");
            }
        }
        ammo--;
    }

    IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(0.3f);
        muzzleFlash.SetActive(false);
    }

    public void Reload()
    {
        ammo = startAmmo;
        ammoText.text = "Ammo: " + ammo;
    }

    IEnumerator ShootingCoolDownRoutine()
    {
        isShot = false;
        yield return new WaitForSeconds(1);
        //ammo = startAmmo;
        isShot = true;
    }

    IEnumerator CoolDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
    }

    public void _addAmmo()
    {
        ammo = startAmmo;
    }
}
