using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject greenI, redI, herbI,bagPannel;

    [SerializeField]
    private ItemEffect itemEffect;

   

    private void Start()
    {
        
    }

    public void UseHerb()
    {

        if (herbI.activeSelf)
        {
            herbI.SetActive(false);
            bagPannel.SetActive(false);
            itemEffect.ItemUse();
            
        }

    }

    public void UseGreen()
    {
        if (greenI.activeSelf)
        {
            greenI.SetActive(false);
            bagPannel.SetActive(false);
            itemEffect.GreenHold();
        }
    }

    public void UseRed()
    {
     if (redI.activeSelf)
        {
            redI.SetActive(false);
            bagPannel.SetActive(false);
            itemEffect.RedHold();
        }
    }

    
}
