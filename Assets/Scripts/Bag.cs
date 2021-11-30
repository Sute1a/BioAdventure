using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    [SerializeField]
    private GameObject bagPannel;

    [SerializeField]
    private GameObject greenT, redT,herb;

        [SerializeField]
    private GameObject greenI, redI, herbI;

    [SerializeField]
    private Button greenU, redU, herbU;

    public Animator animator;

    private void Update()
    {
        
    
    
       if(Input.GetKeyDown(KeyCode.O))
        {
            bagPannel.SetActive(true);
            animator.enabled = false;
        }
    

   
        if (Input.GetKeyDown(KeyCode.C))
        {
            bagPannel.SetActive(false);
            animator.enabled = true;
        }


        if (greenT == null)
        {
            greenI.SetActive(true);
        }
        else if (redT == null)
        {
            redI.SetActive(true);
        }
        else if (herb == null)
        {
            herbI.SetActive(true);
        }
        //bool型に変更してUpdate()を制限で解決？？
        
    }

    


}
