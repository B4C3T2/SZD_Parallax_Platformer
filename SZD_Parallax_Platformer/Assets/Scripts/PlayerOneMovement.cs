using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerOneMovement : MonoBehaviour
{
    public Animator animator; // for animation
    public float movementSpeed;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet, head, left, right;
    public LayerMask groundLayers;
    public List<LayerMask> trapLayers;
    private LayerMask currentTrapLayer;
    public LayerMask endLayers;
    public Text scoreManager;
    public Text nameTag;
    public List<GameObject> archs;
    public GameObject spawnPoint;
    float mx;
    string horizontalvariable;

    private void Start()
    {

        currentTrapLayer = trapLayers[0];
        Physics2D.IgnoreLayerCollision(11, 3, false);
        Physics2D.IgnoreLayerCollision(11, 7, false);
        Physics2D.IgnoreLayerCollision(11, 10, true);
        Physics2D.IgnoreLayerCollision(11, 12, true);
        string file = Application.persistentDataPath + "/Value.txt";
        StreamReader sr = new StreamReader(file);
        string[] array = File.ReadAllLines(file);
        nameTag.text = array[4];
        sr.ReadLine();
        if (sr.ReadLine() == "FaceToFace")
        {
            sr.Close();
            scoreManager.text = nameTag.text+": 0";     
        }
        sr.Close();
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
            SetCollision();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && InArch())
        {
            Transfer();
        }

        if (Ended())
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/Value.txt");
            sr.ReadLine();
            if (sr.ReadLine() == "FaceToFace")
            {
                sr.Close();
                string file = Application.persistentDataPath + "/Value.txt";
                string[] array = System.IO.File.ReadAllLines(file);
                array[2] = (int.Parse(array[2]) + 1).ToString();
                System.IO.File.WriteAllLines(file, array);
                scoreManager.text = nameTag.text + ": " + array[2];
            }
            sr.Close();
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

    public bool InArch()
    {
        foreach (var arch in archs)
        {
            if (transform.position.x <= arch.transform.position.x + 0.1f &&
                transform.position.x > arch.transform.position.x - 0.1f)
            {
                return true;
            }
        }

        return false;
    }

    public bool SteppedIntoTrap()
    {
        List<Collider2D> trapCheck = new List<Collider2D>();
        trapCheck.Add(Physics2D.OverlapCircle(feet.position, 0.15f, currentTrapLayer));
        trapCheck.Add(Physics2D.OverlapCircle(head.position, 0.15f, currentTrapLayer));
        trapCheck.Add(Physics2D.OverlapCircle(left.position, 0.15f, currentTrapLayer));
        trapCheck.Add(Physics2D.OverlapCircle(right.position, 0.15f, currentTrapLayer));

        foreach (Collider2D item in trapCheck)
        {
            if(item != null)
            {
                return true;
            }
        }

        return false;
    }

    public void Transfer()
    {
        if (transform.position.z == 0)
        {
            transform.position += new Vector3(0f, 0f, 2f);
            SetCollision();
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, 2f);
            SetCollision();
        }
    }

    public void SetCollision()
    {
        Physics2D.IgnoreLayerCollision(11, 3, transform.position.z == 2);
        Physics2D.IgnoreLayerCollision(11, 7, transform.position.z == 2);
        Physics2D.IgnoreLayerCollision(11, 10, transform.position.z != 2);
        Physics2D.IgnoreLayerCollision(11, 12, transform.position.z != 2);
        currentTrapLayer = trapLayers[transform.position.z == 2 ? 1 : 0];
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

