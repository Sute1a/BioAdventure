using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.AI;

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

    public BoxCollider Nife,Pick;

    public GameObject MainCam, AttackCam;

    [SerializeField]
    private GameObject GreenOrb, RedOrb;

    public BoxCollider ClearJuge;

    [SerializeField]
    private GameState state;
    [SerializeField]
    private GameObject GC, GO,p0,GS;

    public  NavMeshAgent  agentP;

    private float originCamPos;

    public float waitTime, dis, toTime,waitingTime,backTime;


    public AudioSource audioSource;
    public AudioClip Healing;

    //public CapsuleCollider playerC;

    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;


        hpBer.value = playerHP;

        originCamPos = MainCam.transform.localPosition.z;
       
        //transform .position =new Vector3(-9.26,1.150002,-1);

        
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

            if (GreenOrb.activeSelf==false && RedOrb.activeSelf == false)
            {
                Nife.gameObject.SetActive(true);
                animator.SetTrigger("attack");

                DOTween.Sequence()
                    .Append(MainCam.transform.DOLocalMoveZ(dis, toTime)).SetDelay(waitTime)
                    .AppendInterval(waitingTime)
                    .Append(MainCam.transform.DOLocalMoveZ(originCamPos, backTime));

               // MainCam.transform.DOLocalMoveZ(dis, toTime).SetDelay(waitTime).OnComplete(()
                 //   => MainCam.transform.DOLocalMoveZ(originCamPos, backTime));
            }
            else if (GreenOrb.activeSelf || RedOrb.activeSelf)
            {
                Nife.gameObject.SetActive(false);
                animator.SetTrigger("item");
            }

        }



        if (Input.GetMouseButtonDown(1))
        {
            Nife.gameObject.SetActive(false);
            animator.SetTrigger("item");

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

   



    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        // transform.position += new Vector3(x, 0, z);
        if (agentP.enabled ==true)
        {


            transform.position += cam.transform.forward * z + cam.transform.right * x;
            
        }
    }

    public void UpdateCursorLock()
    {
        if ( Input.GetKeyDown(KeyCode.Escape))
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
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, MaxX); ;

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

   

    public void TakeHit(float attackDamage)
    {
        playerHP = (int)Mathf.Clamp(playerHP - attackDamage, 0, playerHP);

        hpBer.value = playerHP;

        if (playerHP <= 0 && GameState.GameOver == false)
        {
            GameState.GameOver = true;
            Debug.Log("ゲームオーバー");
            state.Over();
        }
    }


    public void Heal()
    {

        if (playerHP < 100)
        {
            Debug.Log("3");
            playerHP = maxPlayerHP;
            hpBer.value = playerHP;
            HealSE();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "GameClear")
        {
            GameState.GameClear = true;
            Debug.Log("Clear");
            transform.DOMoveX(30.5f, 4f);
            state.Clear();

            //animator.SetBool("walk",true);
        }

        if (collision.gameObject.name == "Start")
        {
            GS.SetActive(false);
        }


       

    }

    public void HealSE()
    {
        Debug.Log("9");
        audioSource.clip = Healing;
        audioSource.Play();
    }
}
