using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nife2 : MonoBehaviour
{
    [SerializeField]
    private BoxCollider nifeCollider, pickcollider;




    public void OnNife()
    {
       
        nifeCollider.enabled = true;
    }

    public void OffNife()
    {
        nifeCollider.enabled = false;
    }

    public void Pick()
    {
        pickcollider.enabled = true;
    }

    public void EndPick()
    {
        pickcollider.enabled = false;
    }
}
