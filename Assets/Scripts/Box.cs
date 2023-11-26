using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private int portalCooldown;

    // Update is called once per frame
    void Update()
    {
        portalCooldown++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkPortal" && GameObject.FindGameObjectsWithTag("GreenPortal") != null && portalCooldown >= 50)
        {
            portalCooldown = 0;
            transform.position = GameObject.FindGameObjectsWithTag("GreenPortal")[0].transform.position;
        }

        else if (collision.tag == "GreenPortal" && GameObject.FindGameObjectsWithTag("PinkPortal") != null && portalCooldown >= 50)
        {
            portalCooldown = 0;
            transform.position = GameObject.FindGameObjectsWithTag("PinkPortal")[0].transform.position;
        }

    }
}
