using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Tresure")
        {
            Debug.Log("Destroy");
            Destroy(collision.gameObject ,1.0f );
        }
    }
}
