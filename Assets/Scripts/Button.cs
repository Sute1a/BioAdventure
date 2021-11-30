using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject greenI, redI, herbI;

    public void UseItem()
    {
        if (herbI.activeSelf)
        {
            Destroy(herbI);
        }
        
    }
}
