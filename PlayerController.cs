using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D _body;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float horizontal;
    public float walk = 10f;
    public float bounce = 20f;
    public bool isFacingRight = true;

    public GameObject green;
    public GameObject gPortal;

    public GameObject pink;
    public GameObject pPortal;

    private int portalCooldown;

    void Start()
    {
        portalCooldown = 1000;
    }

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

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

    private void FixedUpdate()
    {
        _body.velocity = new Vector2(horizontal * walk, _body.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            _body.velocity = new Vector2(_body.velocity.x, bounce);
        }

        if (context.canceled && _body.velocity.y > 0f)
        {
            _body.velocity = new Vector2(_body.velocity.x, _body.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1.5f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
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
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 20);
        if (hit.collider != null)
        {
            Debug.Log("hit: " + hit.distance);
            if (colour)
            {
                if (gPortal != null)
                {
                    Destroy(gPortal);
                }
                gPortal = Instantiate(green, hit.point, Quaternion.SetLookRotation(hit.normal, Vector2.up));
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

}
