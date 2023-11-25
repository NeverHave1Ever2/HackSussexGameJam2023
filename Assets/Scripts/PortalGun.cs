using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public GameObject green;
    public GameObject gPortal;

    public GameObject pink;
    public GameObject pPortal;

    public GameObject PortalCaster;
    public GameObject PortalCaster2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointTowardsMouse();
        if (Input.GetButtonDown("Fire1"))
        {
            cast(true);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            cast(false);
        }

    }

    public void cast(bool colour)
    {
        RaycastHit2D hit = Physics2D.Raycast(PortalCaster.transform.position, PortalCaster.transform.up, 20);
        RaycastHit2D hitAngle = Physics2D.Raycast(PortalCaster2.transform.position, PortalCaster2.transform.up, 20);
        if (hit.collider != null)
        { 
            Debug.Log("hit: " + hit.distance);
            if (colour)
            {

                if (gPortal != null)
                {
                    Destroy(gPortal);
                }
                gPortal = Instantiate(green, hit.point, Quaternion.identity);
                gPortal.name = "greenPortal";
            }

            if (!colour)
            {
                if (pPortal != null)
                {
                    Destroy(pPortal);
                }
                pPortal = Instantiate(pink, hit.point, Quaternion.identity);
                pPortal.name = "pinkPortal";
            }
        }
        else Debug.Log("no hit");
    }

    public void pointTowardsMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 Direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = Direction;
    }

}
