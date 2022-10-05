using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
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
                col.ReplaceKey();
            }
            
        }
    }
}
