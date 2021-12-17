using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieControlle : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    public float walkingSpeed;

    enum STATE {IDLE,WANDER,ATTACK,DEAD,CHASE };
    STATE state = STATE.IDLE;

    GameObject target;
    public float runSpeed;

    public int attackDamage;

    public float stopping;

    public AudioClip idleSE, attackSE, deathSE, chaseSE;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void TurnOffTrigger()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);
        animator.SetBool("Death", false);
    }

    float DistanceToPlayer()
    {
        if (GameState.GameOver)
        {
            return Mathf.Infinity;
        }
        return Vector3.Distance(target.transform.position, transform.position);
    }

    bool CanSeePlayer()
    {
        if (DistanceToPlayer() < 15)
        {
            return true;
        }
        audioSource.PlayOneShot(chaseSE);
        return false;
    }

    bool ForGetPlayer()
    {
        if (DistanceToPlayer() > 20)
        {
            return true;
            
        }
audioSource.PlayOneShot(idleSE);
        return false;
    }

    public void DamagePlayer()
    {
        if (target != null)
        {
            if (target.TryGetComponent(out FPSController controller))
            {
                
                    controller.TakeHit(attackDamage);
                
            }
            
        }
    }

    public void ZombieDeath()
    {
        TurnOffTrigger();
        animator.SetBool("Death", true);
        state = STATE.DEAD;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent == null)
        {
            return;
        }

        switch (state)
        {
            case STATE.IDLE:
                TurnOffTrigger();

                if (CanSeePlayer())
                {
                    state = STATE.CHASE;
                    
                }

               else if (Random.Range(0, 5000) < 10)
                {
                    state = STATE.WANDER;
                    
                }
                break;

            case STATE.WANDER:
                if (!agent.hasPath)
                {
                    float newX = transform.position.x + Random.Range(-5, 5);
                    float newZ = transform.position.z + Random.Range(-5, 5);

                    Vector3 NextPos = new Vector3(newX, transform.position.y, newZ);

                    agent.SetDestination(NextPos);
                    agent.stoppingDistance = 0;

                    TurnOffTrigger();

                    agent.speed = walkingSpeed;
                    animator.SetBool("Walk", true);
                }

                if (Random.Range(0, 5000) < 10)
                {
                    state = STATE.IDLE;
                    agent.ResetPath();
                }

                if (CanSeePlayer())
                {
                    state = STATE.CHASE;
                }

                break;

            case STATE.CHASE:

                if (GameState.GameOver)
                {
                    TurnOffTrigger();
                    agent.ResetPath();
                    state = STATE.WANDER;

                    return;
                }

                

                agent.SetDestination(target.transform.position);
                agent.stoppingDistance = 1.5f;

                TurnOffTrigger();

                agent.speed = runSpeed;
                animator.SetBool("Run", true);

                if (agent.remainingDistance<= agent.stoppingDistance )
                {
                    state = STATE.ATTACK;
                }


                if (ForGetPlayer())
                {
                    agent.ResetPath();
                    state = STATE.WANDER;
                }


                break;

            case STATE.ATTACK:
                if (GameState.GameOver)
                {
                    TurnOffTrigger();
                    agent.ResetPath();
                    state = STATE.WANDER;

                    return;
                }

                TurnOffTrigger();
                animator.SetBool("Attack", true);

                transform.LookAt(new Vector3(target.transform.position.x, transform.position.y,
                    target.transform.position.z));


                if (DistanceToPlayer() > agent.stoppingDistance + 1)
                {
                    state = STATE.CHASE;
                }


                break;

            case STATE.DEAD:
                Destroy(gameObject, 3.0f);
                Destroy(agent);
                Debug.Log(agent);
                break;
        }
    }
}
