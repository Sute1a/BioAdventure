using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameState : MonoBehaviour
{
   
    public static bool GameOver=false ;
    public static bool GameClear =false;

    [SerializeField]
    private GameObject GC, GO,Player111;

    


    public void Clear()
    {
        GC.SetActive(true);
        GameClear = true;
        Debug.Log(GameClear);
       
          

            //playerC.enabled = false;
        
    }

    public void Over()
    {
        GO.SetActive(true);
        
        
    }


    public void BackStart()
    {

        Player111.transform.DOJump(new Vector3(-9.28f, 1.2f, -0.96f), jumpPower: 10f, numJumps: 1, duration: 5f);
    }
}
