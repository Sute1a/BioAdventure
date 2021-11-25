using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSimple : MonoBehaviour {

    private Vector3 axis;
	// Use this for initialization
	void Start () {
        axis.Set(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(axis, 200.0f * Time.deltaTime);

    }
}
