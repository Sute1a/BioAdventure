using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject HerbObj,player;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ItemUse()
    {

    

        if (HerbObj == null)
        {
            Debug.Log("w");
            
        }
    }
}
