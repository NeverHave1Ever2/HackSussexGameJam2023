using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject green;
    private GameObject gPortal;

    public GameObject pink;
    private GameObject pPortal;

    private int portalCooldown;

    // Start is called before the first frame update
    void Start()
    {
        portalCooldown = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            cast(true);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            cast(false);
        }

        portalCooldown++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkPortal" && gPortal != null && portalCooldown >= 50)
        {
            portalCooldown = 0;
            transform.position = gPortal.transform.position;
        }

        if (collision.tag == "GreenPortal" && pPortal != null && portalCooldown >= 50)
        {
            portalCooldown = 0;
            transform.position = pPortal.transform.position;
        }
    }

    public void cast(bool colour)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 20);
      //  RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 20);
        if (hit.collider != null)
        {
            Debug.Log("hit: " + hit.distance);
            if (colour)
            {
                if (gPortal != null)
                {
                    Destroy(gPortal);
                }


                Vector3 rot = new Vector3(0f, 0f, hit.normal.x*90f);
               // gPortal = Instantiate(green, hit.point, Quaternion.LookRotation(hit.normal, Vector2.right));
                gPortal = Instantiate(green, hit.point, Quaternion.Euler(rot));
                Debug.Log("normal: " + hit.normal);
               // if 
                gPortal.name = "greenPortal";
            }

            if (!colour)
            {
                if (pPortal != null)
                {
                    Destroy(pPortal);
                }

                Vector3 rot = new Vector3(0f, 0f, hit.normal.x * 90f);
                pPortal = Instantiate(pink, hit.point, Quaternion.Euler(rot));
                pPortal.name = "pinkPortal";
            }
        }
        else Debug.Log("no hit");
    }
}
