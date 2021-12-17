using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieGenerator : MonoBehaviour
{
    NavMeshAgent agent;

    public GameObject ZombiePrefab;
    float span = 10.0f;
    float delta = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;


        if (delta > span)
        {
            float x = Random.Range(6, 23);
            float z = Random.Range(18, 49);
            GameObject Zombie3;
            delta = 0;
            Zombie3 = Instantiate(ZombiePrefab, new Vector3(x, 0.1f, z), Quaternion.identity);




            if (NavMesh.SamplePosition(Zombie3.transform.position,
                out NavMeshHit hit, 50.0f, NavMesh.AllAreas))
            {
                Zombie3.transform.position = hit.position;
            }
        }
    }
}
