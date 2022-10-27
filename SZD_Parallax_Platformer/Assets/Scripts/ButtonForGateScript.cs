using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ButtonForGateScript : MonoBehaviour
{
    public GameObject gateOpen, gateClosed;
    public LayerMask playerLayers;
    // Start is called before the first frame update
    void Start()
    {
        string file = Application.dataPath + "/Value.txt";
        StreamReader sr = new StreamReader(file);
        sr.ReadLine();
        if (sr.ReadLine() == "FaceToFace")
        {
            Destroy(gateClosed);
            Destroy(gameObject);
        }
        sr.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public bool SteppedOn()
    {
        Collider2D collisionCheck = Physics2D.OverlapCircle(transform.position, 0.15f, playerLayers);
        if (collisionCheck != null)
        {
            return true;
        }

        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Physics2D.IgnoreLayerCollision(15, 11, true);
        Physics2D.IgnoreLayerCollision(15, 13, true);
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            gateClosed.transform.position += new Vector3(0f, 0f, 8f);
            gateOpen.transform.position -= new Vector3(0f, 0f, 8f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Physics2D.IgnoreLayerCollision(15, 11, false);
        Physics2D.IgnoreLayerCollision(15, 13, false);
        gateClosed.transform.position -= new Vector3(0f, 0f, 8f);
        gateOpen.transform.position += new Vector3(0f, 0f, 8f);
    }
}
