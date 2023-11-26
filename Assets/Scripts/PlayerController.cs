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
    public float WalkSpeed = 10f;
    public float JumpHeight = 20f;
    public Transform respawnPoint;

    private float horizontal;
    private bool isFacingRight = true;


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
    }

    private void FixedUpdate()
    {
        _body.velocity = new Vector2(horizontal * WalkSpeed, _body.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            _body.velocity = new Vector2(_body.velocity.x, JumpHeight);
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

    public void OnPlayerHitCheckPoint(CheckPoint checkPoint)
    {
        respawnPoint.position = checkPoint.transform.position;
    }

    public void OnPlayerHitObsticle()
    {
        _body.position = respawnPoint.position;
        _body.velocity = Vector2.zero;
    }
}
