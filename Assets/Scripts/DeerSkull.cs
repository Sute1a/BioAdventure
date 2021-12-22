using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerSkull : MonoBehaviour
{

    [SerializeField]
    private GameObject greenEye, redEye;


    [SerializeField]
    private Door door;

    public AudioSource audioSource;
    public AudioClip Eye;

    private void OnTriggerEnter(Collider collision)
    {
        
    

    Debug.Log(collision.gameObject);

        if (collision.gameObject.name == "GreenOrb")
        {
            EyeFlush();
            greenEye.SetActive(true);
            collision.gameObject.SetActive(false);

            if (redEye.activeSelf)
            {
                door.Open();
            }
        }
        else if (collision.gameObject.name == "RedOrb")
        {
            EyeFlush();
            redEye.SetActive(true);
            collision.gameObject.SetActive(false);

            if (greenEye.activeSelf)
            {
                door.Open();
            }
        }
    }

    public void EyeFlush()
    {
        audioSource.clip = Eye;
        audioSource.Play();
    }
}

