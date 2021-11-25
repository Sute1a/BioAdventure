using RGemEffectPlugin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PfxSetting : MonoBehaviour {

    private bool restoreDofFlag = false;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);

        var ppb = Camera.main.GetComponent<PostProcessingBehaviour>();
        if (ppb)
        {
            restoreDofFlag = ppb.profile.depthOfField.enabled;
        }
    }

    public void OnChangeDepthOfField(bool enable)
    {
        var ppb = Camera.main.GetComponent<PostProcessingBehaviour>();

        if(ppb)
        {
            ppb.profile.depthOfField.enabled = enable;
        }
    }

    void OnApplicationQuit()
    {
        var ppb = Camera.main.GetComponent<PostProcessingBehaviour>();
        if (ppb)
        {
            ppb.profile.depthOfField.enabled = restoreDofFlag;
        }
    }
}
