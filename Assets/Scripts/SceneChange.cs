using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    private GameObject GS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
            GS.SetActive(false);
        }

        if (GameState.GameClear || GameState.GameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameState.GameClear = false;
                GameState.GameOver = false;

                SceneManager.LoadScene("Start");
                
            }
        }
    }
}
