using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    public Animator animator; // for animation

    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    public LayerMask trapLayers;
    public GameObject spawnPoint;

    float mx;

    private void Update()
    {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrouned())
        {
            Jump();
        }

        if(SteppedIntoTrap())
        {
            transform.position = spawnPoint.transform.position;
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }
    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    public bool IsGrouned()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }

    public bool SteppedIntoTrap()
    {
        Collider2D trapCheck = Physics2D.OverlapCircle(feet.position, 0.15f, trapLayers);

        if (trapCheck != null)
        {
            return true;
        }

        return false;
    }
}

