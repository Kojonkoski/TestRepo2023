using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //This is for setting up a player speed
    [Header("Player movement")]
    [Range(0.1f,30f)]
    public float playerSpeed = 10f;

    //This is for setting up an object for bullet and followed object for aiming.
    [Header ("Shooting")]
    public GameObject bullet;
    public Transform gun;

    [Range(0.1f, 0.5f)]
    public float fireRate = 0.5f;
    public bool canFire = true;

    // This is for setting up gamemode
    [Header("Game mode")]
    public bool twinstick = false;
    public bool mouseaim = false;
    public bool classic = false;

    // Start is called before the first frame update
    void Start()
    {
        if (twinstick)
        {
            gun.GetComponent<TwinStickAim>().enabled = true;
            gun.GetComponent<GunScript>().enabled = false;

        }
        else if(classic)
        {
            gun.GetComponent<TwinStickAim>().enabled = false;
            gun.GetComponent<GunScript>().enabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        // This is for moving the player horizontally and vertically
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hor*playerSpeed*Time.deltaTime, ver*playerSpeed*Time.deltaTime, 0));

        // This is for shooting

        if(!twinstick && Input.GetButtonDown("Fire1") && canFire)
        {
            StartCoroutine("Shoot");
        }
    }

    public IEnumerator Shoot()
    {
        Instantiate(bullet, gun.transform.position,gun.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }



}
