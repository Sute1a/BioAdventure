using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nife : MonoBehaviour
{
    [SerializeField]
    private GameObject Barrell0, Barrell1;

    [SerializeField]
    private MeshRenderer meshRenderer0, meshRenderer1;
    

    private void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out ZombieControlle zombie))
        {
            zombie.ZombieDeath();
            // Debug.Log("Zombie");
        }

        else if (collision.gameObject.tag == "Barrell")
        {
           collision.gameObject.SetActive(false);
            if (collision.gameObject == Barrell0)
            {
                meshRenderer0.enabled = true;
            }

            else if(collision.gameObject == Barrell1)
            {
                meshRenderer1.enabled = true;
            }
           
           // Debug.Log("Barrell");
        }

    }


   
}
