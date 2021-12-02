using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    [SerializeField]
    private GameObject bagPannel;

    [SerializeField]
    private GameObject greenI, redI, herbI;
    
    public Animator animator;

    [SerializeField]
    private GameObject GT, RT, Herb;

    bool greenT,redT,herb = false;

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


        if (!greenT && GT==null)
        {
            greenI.SetActive(true);
            greenT = true;
        }
        else if (!redT && RT==null)
        {
            redI.SetActive(true);
            redT = true;
        }
        else if (!herb && Herb==null)
        {
            herbI.SetActive(true);
            herb = true;
        }
        //bool型に変更してUpdate()を制限で解決？？
        
    }

    


}
