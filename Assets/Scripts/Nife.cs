using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nife : MonoBehaviour
{
   


    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent(out ZombieControlle zombie))
        {
            zombie.ZombieDeath();
           // Debug.Log("ww");
        }
    }

      
    
}
