using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerTwoMovement : MonoBehaviour
{
    public Animator animator; // for animation
    public float movementSpeed;
    public Rigidbody2D rb;
    private float jumpForce;
    public Transform feet, head, left, right;
    public List<LayerMask> trapLayers, groundLayers;
    private LayerMask currentTrapLayer, currentGroundLayer;
    public LayerMask endLayers;
    public Text scoreManager;
    public Text nameTag;
    public List<GameObject> archs;
    public GameObject spawnPoint;
    float mx;
    string horizontalvariable;
    public bool isKeyPickedUp;
    private void Start()
    {
        isKeyPickedUp = false;
        jumpForce = 10f;
        currentTrapLayer = trapLayers[0];
        currentGroundLayer = groundLayers[0];
        Physics2D.IgnoreLayerCollision(13, 3, false);
        Physics2D.IgnoreLayerCollision(13, 7, false);
        Physics2D.IgnoreLayerCollision(13, 10, true);
        Physics2D.IgnoreLayerCollision(13, 12, true);
        string file = Application.dataPath + "/Value.txt";
        StreamReader sr = new StreamReader(file);
        string[] array = File.ReadAllLines(file);
        nameTag.text = array[5];
        sr.ReadLine();
        if (sr.ReadLine() == "FaceToFace")
        {
            sr.Close();
            scoreManager.text = nameTag.text+": 0";
        }
        sr.Close();
        
        if (SkinManager.P2Id == 1)
        {
            horizontalvariable = "Horizontal1";
            animator.runtimeAnimatorController = Resources.Load("Aquaman") as RuntimeAnimatorController;
        }
        if (SkinManager.P2Id == 2)
        {
            horizontalvariable = "Horizontal2";
            animator.runtimeAnimatorController = Resources.Load("Avatar") as RuntimeAnimatorController;
        }
        if (SkinManager.P2Id == 3)
        {
            horizontalvariable = "Horizontal3";
            animator.runtimeAnimatorController = Resources.Load("Pennywise") as RuntimeAnimatorController;
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Joystick2Button4))
        {
            animator.SetFloat(horizontalvariable, Input.GetAxis("Horizontal"));
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Joystick2Button5))
        {
            animator.SetFloat(horizontalvariable, Input.GetAxis("Horizontal"));
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            
        }
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) || (Input.GetKey(KeyCode.Joystick2Button4) || Input.GetKey(KeyCode.Joystick2Button5)))
        {
            animator.SetFloat(horizontalvariable, 0f);
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.Joystick2Button0)) && IsGrouned())
        {       
            Jump();
        }
        
        if(SteppedIntoTrap())
        {
            transform.position = spawnPoint.transform.position;
            SetCollision();
        }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.Joystick2Button1)) && InArch())
        {
            if(isKeyPickedUp)
                Transfer();
        }

        if (Ended())
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/Value.txt");
            sr.ReadLine();
            if (sr.ReadLine() == "FaceToFace")
            {
                sr.Close();
                string file = Application.dataPath + "/Value.txt";
                string[] array = System.IO.File.ReadAllLines(file);
                array[3] = (int.Parse(array[3]) + 1).ToString();
                System.IO.File.WriteAllLines(file, array);
                scoreManager.text = nameTag.text + ": " + array[3];
            }
            sr.Close();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        string valueIsTrue = Application.dataPath + "/Value.txt";
        string[] changedArray = File.ReadAllLines(valueIsTrue);
        if (changedArray[1] == "TimeRush")
        {
            if (changedArray[6] == "true")
                isKeyPickedUp = true;
            else
                isKeyPickedUp = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx*movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }
    void Jump()
    {
        
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    public bool IsGrouned()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.2f, currentGroundLayer);

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
            if (item != null)
            {
                isKeyPickedUp = false;
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
        Physics2D.IgnoreLayerCollision(13, 3, transform.position.z == 2);
        Physics2D.IgnoreLayerCollision(13, 7, transform.position.z == 2);
        Physics2D.IgnoreLayerCollision(13, 10, transform.position.z != 2);
        Physics2D.IgnoreLayerCollision(13, 12, transform.position.z != 2);
        currentTrapLayer = trapLayers[transform.position.z == 2 ? 1 : 0];
        currentGroundLayer = groundLayers[transform.position.z == 2 ? 1 : 0];
    }

    public bool Ended()
    {
        Collider2D endCheck = Physics2D.OverlapCircle(feet.position, 0.15f, endLayers);

        if (endCheck != null)
        {
            string file = Application.dataPath + "/Value.txt";
            string[] array = File.ReadAllLines(file);
            array[6] = "false";
            File.WriteAllLines(file, array);
            return true; 
        }

        return false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            Collected(other.GetComponent<CollectManager>());
        }
    }

    private void Collected(CollectManager col)
    {
        if (col.Collect())
        {
            if (col is CollectedKey)
            {
                Debug.Log("Key collected");
                string file = Application.dataPath + "/Value.txt";
                string[] array = File.ReadAllLines(file);
                string map = array[1];
                if (map == "TimeRush")
                {
                    array[6] = "true";
                    File.WriteAllLines(file, array);
                }
                isKeyPickedUp = true;
                col.ReplaceKey();
            }
            else
            {
                Debug.Log("Cape collected");
                StartCoroutine(CapeInUse());
                col.ReplaceCape();
            }
        }
    }
    IEnumerator CapeInUse()
    {
        jumpForce = 15f;
        yield return new WaitForSeconds(10f);
        jumpForce = 10f;
    }
}
