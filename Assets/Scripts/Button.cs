using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject greenI, redI, herbI,bagPannel;

    

    private void Start()
    {
        
    }

    public void UseItem()
    {
        bagPannel.SetActive(false);
        if (herbI.activeSelf)
        {
            Destroy(herbI);
        }

       else if (greenI.activeSelf)
        {
            Destroy(greenI);
        }

       else if (redI.activeSelf)
        {
            Destroy(redI);
        }
    }
}
