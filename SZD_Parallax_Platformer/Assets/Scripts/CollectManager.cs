using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    private bool isCollected = false;
    public int zero = 0;
    public bool Collect()
    {
        if (isCollected)
            return false;      
        isCollected = true;
        gameObject.transform.position += new Vector3(0f, 0f, 7f);
        return true;       
    }
    public void ReplaceKey()
    {
        StartCoroutine(Wait());      
    }
    private IEnumerator Wait()
    {  
        yield return new WaitForSeconds(5f);
        gameObject.transform.position -= new Vector3(0f, 0f, 7f);
        isCollected = false;
    }



}
