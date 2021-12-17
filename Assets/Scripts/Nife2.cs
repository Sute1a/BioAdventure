using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nife2 : MonoBehaviour
{
    [SerializeField]
    private BoxCollider nifeCollider, pickcollider,clawcolliderRight,clawcolliderLeft;




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

    public void OnRightClaw()
    {
        clawcolliderRight.enabled = true;
    }

    public void OffRightClaw()
    {
        clawcolliderRight.enabled = false;
    }

    public void OnLeftClaw()
    {
        clawcolliderLeft.enabled = true;
    }

    public void OffLeftClaw()
    {
        clawcolliderLeft.enabled = false;
    }
}
