using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPortal : MonoBehaviour
{
    public GameObject pinkPortal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pinkPortal = GameObject.Find("pinkPortal");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && pinkPortal != null)
        {
            collision.transform.position = pinkPortal.transform.position;
        }
    }
}
