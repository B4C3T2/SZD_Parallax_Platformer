using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistScript : MonoBehaviour
{
    public Transform StartPos, EndPos, Trigger;
    Vector3 Destination;
    public LayerMask playerLayers;
    private bool notMoving;

    void Start()
    {
        transform.position = StartPos.position;
        notMoving = true;
    }


    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (HitTrigger() && notMoving)
        {
            StartCoroutine(Strike());
            StartCoroutine(Reset());
        }
    }

    private bool HitTrigger()
    {
        Collider2D triggerCheck = Physics2D.OverlapCircle(Trigger.transform.position, 0.55f, playerLayers);

        if (triggerCheck != null)
        {
            return true;
        }

        return false;
    }
    IEnumerator Strike()
    {
        notMoving = false;
        transform.position = Vector3.MoveTowards(transform.position, EndPos.transform.position, 3f * Time.deltaTime);
        while (transform.position != EndPos.transform.position)
        {
            yield return new WaitForSeconds(0.001f);
            transform.position = Vector3.MoveTowards(transform.position, EndPos.transform.position, 3f * Time.deltaTime);
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2f);
        while (transform.position != StartPos.transform.position)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position = Vector3.MoveTowards(transform.position, StartPos.transform.position, 2f * Time.deltaTime);
        }
        notMoving = true;
    }
}
