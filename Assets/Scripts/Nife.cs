using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nife : MonoBehaviour
{
    [SerializeField]
    private GameObject Barrell0, Barrell1;

    [SerializeField]
    private MeshRenderer meshRenderer0, meshRenderer1;

    public AudioSource audioSourceKill,audioSourceB0,audioSourceB1;
    public AudioClip KillClip, BreakClip0,BreakClip1;
   


    private void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out ZombieControlle zombie))
        {
            Debug.Log(null);
            KillSE();
            zombie.ZombieDeath();
            // Debug.Log("Zombie");
        }

        else if (collision.gameObject.tag == "Barrell")
        {
            
              
            
            
             
            
                
        
            if (collision.gameObject == Barrell0)
            {
                BarrellBreak0();
               
                Barrell0.SetActive(false);
                meshRenderer0.enabled = true;
                Destroy(audioSourceB0,1);
            }

            else if (collision.gameObject == Barrell1)
            {
                     BarrellBreak1();
                
                Barrell1.SetActive(false);
                meshRenderer1.enabled = true;
                Destroy(audioSourceB1,1);
            }

            // Debug.Log("Barrell");
        }

    }

    public void KillSE()
    {
        audioSourceKill.clip = KillClip;
        audioSourceKill.Play();
    }

    public void BarrellBreak0()
    {
        if (audioSourceB0 != null)
        {


            audioSourceB0.clip = BreakClip0;

            audioSourceB0.Play();

            Debug.Log("3");


           
        }
    }

    public void BarrellBreak1()
    {
        if (audioSourceB1 != null)
        {


            audioSourceB1.clip = BreakClip1;

            audioSourceB1.Play();

            Debug.Log("6");



        }
    }
}