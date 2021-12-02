using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerSkull : MonoBehaviour
{

    [SerializeField]
    private GameObject greenEye, redEye;





    private void OnTriggerEnter(Collider collision)
    {
        
    

    Debug.Log(collision.gameObject);

        if (collision.gameObject.name == "GreenOrb")
        {
            greenEye.SetActive(true);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "RedOrb")
        {

            redEye.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}

