using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nife2 : MonoBehaviour
{
    [SerializeField]
    private BoxCollider boxCollider;



    public void OnNife()
    {
        boxCollider.enabled = true;
    }

    public void OffNife()
    {
        boxCollider.enabled = false;
    }
}
