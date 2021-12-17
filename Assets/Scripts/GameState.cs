using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class GameState : MonoBehaviour
{
   
    public static bool GameOver=false ;
    public static bool GameClear =false;
    public static bool GameStart = true;

    [SerializeField]
    private GameObject GC, GO,Player111,start,p0;

   


    private void Start()
    {
        start.SetActive(true);
        GameStart = true;
    }




    public void Clear()
    {
        GC.SetActive(true);
        
        
    }

    public void Over()
    {
        GO.SetActive(true);
        
        
    }


   

   



}
