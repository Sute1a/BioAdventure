using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrell : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Nife")
            if(particle != null)

        
        {
            particle.Play();
            Debug.Log("nife");
            Destroy(particle, 1.5f);
        }
    }
}