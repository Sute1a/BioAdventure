using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffect : MonoBehaviour
{
    [SerializeField]
    private FPSController player;

    [SerializeField]
    private GameObject greenOrb, redOrb;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ItemUse()
    {

        player.Heal();
        Debug.Log("w");
    }

    public void GreenHold()
    {
        greenOrb.SetActive(true);
        player.Nife.gameObject.SetActive(false);
    }

    public void RedHold()
    {
        redOrb.SetActive(true);
        player.Nife.gameObject.SetActive(false);
    }

   
}
