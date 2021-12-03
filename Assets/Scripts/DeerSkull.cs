using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerSkull : MonoBehaviour
{

    [SerializeField]
    private GameObject greenEye, redEye;


    [SerializeField]
    private Door door;


    private void OnTriggerEnter(Collider collision)
    {
        
    

    Debug.Log(collision.gameObject);

        if (collision.gameObject.name == "GreenOrb")
        {
            greenEye.SetActive(true);
            collision.gameObject.SetActive(false);

            if (redEye.activeSelf)
            {
                door.Open();
            }
        }
        else if (collision.gameObject.name == "RedOrb")
        {

            redEye.SetActive(true);
            collision.gameObject.SetActive(false);

            if (greenEye.activeSelf)
            {
                door.Open();
            }
        }
    }
}

