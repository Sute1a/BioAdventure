using RGemEffectPlugin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGemParam : MonoBehaviour {

    public List<GameObject> gems;

	// Use this for initialization
	void Start () {
		
	}
	
    public void OnChangeTraceMode(int mode)
    {
        int traceCount = 3;
        switch (mode)
        {
            case 0:
                traceCount = 3;
                break;
            case 1:
                traceCount = 5;
                break;
            case 2:
                traceCount = 10;
                break;
        }

        foreach(var gem in gems)
        {
            var param = gem.GetComponent<GemParameters>();
            param.updateCount(traceCount);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
