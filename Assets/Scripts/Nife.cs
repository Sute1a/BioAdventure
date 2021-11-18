using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nife : MonoBehaviour
{




    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ZombieControlle>())
        {
            ZombieKill();
        }
    }

      
    public void ZombieKill()
    {
        GetComponent<ZombieControlle>().ZombieDeath();
    }
}
