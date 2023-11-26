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
    private int portalCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointTowardsMouse();
    }

    public void pointTowardsMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 Direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = Direction;
    }

}

