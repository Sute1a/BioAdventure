using UnityEngine;
using System.Collections;

// リングを周囲に配置するスクリプト
public class SetupRing : MonoBehaviour
{
    public GameObject goldRing = null;  // prefabに登録したリング
    public int ringCount = 32;          // 周りに配置するリングの数
    public Material silverRing = null;  // シルバーマテリアル

    // Use this for initialization
    void Start()
    {
        setupRings();
    }

    void setupRings()
    {
        if (goldRing == null || silverRing == null)
        {
            return;
        }

        int cnt = ringCount; // 配置する数

        for (int i = 0; i < cnt; i++)
        {
            float r = 3.6f;

            Vector3 pos = new Vector3(
                Mathf.Cos(Mathf.Deg2Rad * (360.0f) / cnt * i) * r,
                0.40f,
                Mathf.Sin(Mathf.Deg2Rad * (360.0f) / cnt * i) * r);

            var ring = Instantiate(
                goldRing,
                pos,
                Quaternion.Euler(90, ((-360.0f) / cnt * i), 0)) as GameObject;

            Vector3 scale = new Vector3(0.4f, 0.4f, 0.4f);

            ring.transform.localScale = scale;


            // 交互にゴールドとシルバーマテリアルを配置
            if (ring != null && (i%2==0))
            {
                var rndr = ring.GetComponentInChildren<Renderer>();
                if(rndr)
                {
                    rndr.sharedMaterial = silverRing;
                }
            }
        }
    }
}
