using RGemEffectPlugin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGemEffectPlugin
{
    public class SpawnGem : MonoBehaviour
    {
        [SerializeField]
        public bool enableRotation = true;

        public GameObject prefabGem = null;

        /// <summary>
        /// private values.
        /// </summary>
        private float hue = 0.0f;
        private float scaleFreq = 0.0f;
        private float iorFreq = 0.0f;
        private GemParameters gemParam = null;
        private GameObject gem = null;

        // Use this for initialization
        void Start()
        {
            if (prefabGem)
            {
                gem = Instantiate(prefabGem, Vector3.zero, Quaternion.identity);
                gemParam = gem.GetComponent<GemParameters>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (enableRotation)
            {
                gem.transform.Rotate(Vector3.up, 20.0f * Time.deltaTime);
            }

            // Change gem color.
            if (gemParam)
            {
                hue += 0.2f * Time.deltaTime;
                if (hue > 1.0f)
                {
                    hue -= 1.0f;
                }

                var color = Color.HSVToRGB(hue, 0.25f, 0.9f);

                gemParam.UpdateColor(color);

                // Change gem scale.
                scaleFreq += (Mathf.Deg2Rad * 20.0f) * Time.deltaTime;
                if (scaleFreq > Mathf.PI * 2.0f)
                {
                    scaleFreq -= Mathf.PI * 2.0f;
                }

                // Change ior.
                iorFreq += (Mathf.Deg2Rad * 20.0f) * Time.deltaTime;
                if (iorFreq > Mathf.PI * 2.0f)
                {
                    iorFreq -= Mathf.PI * 2.0f;
                }

                gemParam.UpdateParam(scaleFreq, iorFreq);
            }
        }
    }

    
};
