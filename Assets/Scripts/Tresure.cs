using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tresure : MonoBehaviour
{
    public ParticleSystem particle;
    public ParticleSystem particleLight;

    private MeshRenderer mesh;

    [SerializeField]
    private BoxCollider nifecollider;

    private void Start()
    {
        
       
    }




    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag=="Nife")
            if(particle!=null)
        {
            particle.Play();
            Debug.Log("nife");
            Destroy(particle, 1.5f);
        }
            else if(particleLight!=null)

            {
                particleLight.Play();
                Debug.Log("Nife2");
            }
    }
    

}