using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPortal : MonoBehaviour
{
    public GameObject greenPortal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        greenPortal = GameObject.Find("greenPortal");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && greenPortal != null)
        {
            collision.transform.position = greenPortal.transform.position;
            collision.tag = "PlayerGreen";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerPink")
        {
            collision.tag = "Player";
        }
    }
}
