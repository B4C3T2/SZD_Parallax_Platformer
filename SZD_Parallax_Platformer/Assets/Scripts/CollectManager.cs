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
        StartCoroutine(WaitForKey());      
    }
    private IEnumerator WaitForKey()
    {  
        yield return new WaitForSeconds(5f);
        gameObject.transform.position -= new Vector3(0f, 0f, 7f);
        isCollected = false;
    }
    public void ReplaceCape()
    {
        StartCoroutine(WaitForCape());
    }
    private IEnumerator WaitForCape()
    {      
        yield return new WaitForSeconds(10f);
        gameObject.transform.position = new Vector3(0f,0f,0f);
        gameObject.transform.position -= new Vector3(Random.Range(-9, 11), Random.Range(-4, 5), 7f);
        isCollected = false;
    }



}
