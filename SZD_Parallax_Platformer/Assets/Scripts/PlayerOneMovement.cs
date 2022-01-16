using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOneMovement : MonoBehaviour
{
    public Animator animator; // for animation
    public float movementSpeed;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet, head, left, right;
    public LayerMask groundLayers;
    public LayerMask trapLayers;
    public LayerMask endLayers;
    public GameObject spawnPoint;
    float mx;
    string horizontalvariable;

    private void Start()
    {
        if (SkinManager.P1Id == 1)
        {
            horizontalvariable = "Horizontal1";
            animator.runtimeAnimatorController = Resources.Load("Aquaman") as RuntimeAnimatorController;
        }
        if (SkinManager.P1Id == 2)
        {
            horizontalvariable = "Horizontal2";
            animator.runtimeAnimatorController = Resources.Load("Avatar") as RuntimeAnimatorController;
        }
        if (SkinManager.P1Id == 3)
        {
            horizontalvariable = "Horizontal3";
            animator.runtimeAnimatorController = Resources.Load("Pennywise") as RuntimeAnimatorController;
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetFloat(horizontalvariable, Input.GetAxis("Horizontal"));
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }    
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat(horizontalvariable, Input.GetAxis("Horizontal"));
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;     

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetFloat(horizontalvariable, 0f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrouned())
        {
            Jump();
        }
        
        if(SteppedIntoTrap())
        {
            transform.position = spawnPoint.transform.position;
        }

        if(Ended())
        {
            //todo p1 point++; refresh ui;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        List<Collider2D> trapCheck = new List<Collider2D>();
        trapCheck.Add(Physics2D.OverlapCircle(feet.position, 0.15f, trapLayers));
        trapCheck.Add(Physics2D.OverlapCircle(head.position, 0.15f, trapLayers));
        trapCheck.Add(Physics2D.OverlapCircle(left.position, 0.15f, trapLayers));
        trapCheck.Add(Physics2D.OverlapCircle(right.position, 0.15f, trapLayers));

        foreach (Collider2D item in trapCheck)
        {
            if(item != null)
            {
                return true;
            }
        }

        return false;
    }

    public bool Ended()
    {
        Collider2D endCheck = Physics2D.OverlapCircle(feet.position, 0.15f, endLayers);

        if (endCheck != null)
        {
            return true;
        }

        return false;
    }
}

