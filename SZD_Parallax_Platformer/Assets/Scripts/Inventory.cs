using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            Collect(other.GetComponent<CollectManager>());
        }
    }

    private void Collect(CollectManager col)
    {
        if (col.Collect())
        {
            if (col is CollectedKey)
                Debug.Log("Key collected");
        }
    }
}
