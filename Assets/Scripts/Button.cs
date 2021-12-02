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

    public void UseItem()
    {
        bagPannel.SetActive(false);
        if (herbI.activeSelf)
        {
            Destroy(herbI);
            itemEffect.ItemUse();
        }

       else if (greenI.activeSelf)
        {
            Destroy(greenI);
            itemEffect.GreenHold();
        }

       else if (redI.activeSelf)
        {
            Destroy(redI);
            itemEffect.RedHold();
        }
    }
}
