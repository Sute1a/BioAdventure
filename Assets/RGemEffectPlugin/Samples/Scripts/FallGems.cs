using RGemEffectPlugin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGems : MonoBehaviour {

    public GameObject traceObj;
    public GameObject[] gems;
    [SerializeField]
    public bool enableFall = false;
    public int fallCount = 50;
    public float time = 0.3f;
    
    private float elapsedTime = 0.0f;

    // Use this for initialization
    void Start () {
        elapsedTime = time;
    }
	
    public void EnableFall(bool enable)
    {
        this.enableFall = enable;
    }

	// Update is called once per frame
	void Update () {
        if (!enableFall)
            return;

        if (fallCount > 0)
        {
            elapsedTime -= Time.deltaTime;
            if (elapsedTime <= 0.0f)
            {
                CreateGem();

                elapsedTime = time;
                fallCount--;
            }
        }
    }

    void CreateGem()
    {
        var gemType = Random.Range(0, gems.Length);
        GameObject toInstantiate = gems[gemType];

        var len = Random.Range(0, 3.8f);
        var r0 = Random.Range(0, Mathf.PI * 2.0f);

        Vector3 pos = new Vector3(Mathf.Cos(r0) * len, 4, Mathf.Sin(r0) * len);
        var rot = Quaternion.Euler(Random.Range(-90.0f, 90.0f)
                , Random.Range(-90.0f, 90.0f), Random.Range(-90.0f, 90.0f));
        var gemInstance = Instantiate(toInstantiate, pos, rot) as GameObject;

        var param = gemInstance.GetComponent<GemParameters>();

        GemParameters.gemParam a = (GemParameters.gemParam)Random.Range(0, 3);

        param.paramSet = (GemParameters.gemParam)Random.Range(0, 3);

        param.SetRundomSize();

        ChangeGemParam traceComp = traceObj.GetComponent<ChangeGemParam>();
        traceComp.gems.Add(gemInstance);
    }

}
