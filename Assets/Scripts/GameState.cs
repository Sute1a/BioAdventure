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

    public AudioSource audioSource;
    public AudioClip clipClear, clipOver;


    private void Start()
    {
       // start.SetActive(true);
        GameStart = true;
    }




    public void Clear()
    {
        GC.SetActive(true);
        audioSource.PlayOneShot(clipClear);
        
    }

    public void Over()
    {
        GO.SetActive(true);
        audioSource.PlayOneShot(clipOver,2f);
        
    }


   

   



}
