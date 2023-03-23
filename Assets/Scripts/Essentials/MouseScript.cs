using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
        //this is for moving or aiming with mouse
    {
        Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(myray, out hit, Mathf.Infinity, layerMask))
        {
            transform.position = hit.point;

            /*
            if (Input.GetButtonDown("Fire1") && hit.transform.CompareTag("Enemy")) 
            {
                Destroy(hit.transform.gameObject);
            }
            */

        }


    }
}
