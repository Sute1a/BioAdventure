using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    [SerializeField]
    private GameObject greenT, redT, herb, barrell0, barrell1;

    public AudioSource audioSourceG, audioSourceR, audioSourceH;
    public AudioClip GG, RG, HG;

    private void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Tresure")
        {

            if (barrell0.activeSelf == false)
            {
                GetG();
                Destroy(greenT,0.5f);
            }
        }

        else if (collision.gameObject.tag == "Tresure1")
        {


            if (barrell1.activeSelf == false)
            {
                GetR();
                Debug.Log("3");
                Destroy(redT,0.5f);
            }
        }

        
        else if (collision.gameObject == herb)
        {
            GetH();
            Destroy(herb,0.5f);
        }
    }

    public void GetG()
    {
        audioSourceG.clip = GG;
        audioSourceG.Play();
    }

    public void GetR()
    {
        audioSourceR.clip = RG;
        audioSourceR.Play();
    }

    public void GetH()
    {
        audioSourceH.clip = HG;
        audioSourceH.Play();
    }
}
