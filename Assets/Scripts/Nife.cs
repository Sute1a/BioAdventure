using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nife : MonoBehaviour
{
    [SerializeField]
    private BoxCollider boxCollider;



    public void OnNife()
    {
        boxCollider.enabled = true;
    }
    
    public void OffNife()
    {
        boxCollider.enabled = false;
    }


    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent(out ZombieControlle zombie))
        {
            zombie.ZombieDeath();
           // Debug.Log("ww");
        }
    }

      
    
}
