using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotAxis : MonoBehaviour {

    public float xValue = 0.0f;
    public float yValue = 0.0f;
    public float zValue = 0.0f;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xValue * Time.deltaTime, yValue * Time.deltaTime, zValue * Time.deltaTime);
    }

}
