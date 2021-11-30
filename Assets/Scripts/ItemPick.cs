using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    [SerializeField]
    private GameObject greenT ,redT,herb,barrell0,barrell1;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Tresure")
        {

            if (barrell0.activeSelf==false)
            {
                Destroy(greenT);
            }

            else if (barrell1.activeSelf==false)
            {
                Destroy(redT);
            }
        }
        else if (collision.gameObject == herb)
        {
            Destroy(herb);
        }
    }
}
