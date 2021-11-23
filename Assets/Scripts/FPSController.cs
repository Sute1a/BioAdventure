using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    float x, z;
    public float speed;

    public float jumpPower;

    public GameObject cam;
    Quaternion cameraRot, characterRot;

    float Xsensityvity = 3f, Ysensityvity = 3f;

    bool cursorLock = true;

    float minX = -90f, MaxX = 90f;


    public Animator animator;


    int playerHP = 100, maxPlayerHP = 100;
    public Slider hpBer;

    public GameObject MainCam,AttackCam;

    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;


        hpBer.value = playerHP;

       

    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;

        UpdateCursorLock();

        if (Input.GetMouseButtonDown(0))
        {
           // PingPong();
            //MainCam.transform.position += MainCam.transform.forward * 10f * Time.deltaTime;

            animator.SetTrigger("attack");
            
           // AttackCam.transform.position = new Vector3()
           
        }

        if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
                speed = 0.2f;
            }
            else
            {
                animator.SetBool("walk", true);
                animator.SetBool("run", false);
                speed = 0.1f;
            }

        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
        }

    }

    //public static float PingPong(float t, float length);
    


    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal")*speed;
        z = Input.GetAxisRaw("Vertical")*speed;

        // transform.position += new Vector3(x, 0, z);

        transform.position += cam.transform.forward * z + cam.transform.right * x;
    }

    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(1))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /=q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX,minX,MaxX); ;

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    public void TakeHit(float damage)
    {
        playerHP =(int) Mathf.Clamp(playerHP - damage, 0, playerHP);

        hpBer.value = playerHP;

        if (playerHP <= 0&&!GameState.GameOver)
        {
            GameState.GameOver = true;
            Debug.Log("ゲームオーバー");
        }
    }

  
}
