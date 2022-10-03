using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    private bool isCollected = false;
    //Vector3 keyPos;
    public int countDown = 5;
    public int zero = 0;
    public bool Collect()
    {
        if (isCollected)
            return false;
       
        isCollected = true;
        Destroy(gameObject);
        return true; 
        
    }
    /*public void ReplaceKey()
    {
        Wait();               
        Instantiate(gameObject);
    }
    IEnumerator Wait()   
    {
        yield return new WaitForSeconds(5);
    }*/
    
    
}
