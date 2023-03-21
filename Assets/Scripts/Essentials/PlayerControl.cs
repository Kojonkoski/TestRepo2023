using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //This is for setting up a player speed
    [Header("Player movement")]
    [Range(0.1f,30f)]
    public float playerSpeed = 10f;

    //This is for setting up an object for bullet
    [Header ("Shooting")]
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This is for moving the player horizontally and vertically
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hor*playerSpeed*Time.deltaTime, ver*playerSpeed*Time.deltaTime, 0));

        // This is for shooting

        if(Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position,transform.rotation);

    }

}
