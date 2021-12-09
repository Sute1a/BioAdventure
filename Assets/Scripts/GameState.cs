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
   
    }


    public void GamePlay()
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


   public void BackStart()
    {

        Player111.transform.DOJump(new Vector3(-9.28f, 1.2f, -0.96f),
            jumpPower: 10f, numJumps: 1, duration: 5f).OnComplete(()
            => p0.SetActive(true));
       // yield return new WaitForSeconds(1);
       


    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L))
       // {
         //   Application.LoadLevel(0);
       // }
    }




}
