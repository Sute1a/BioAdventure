using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
   
    public void Open()
    {
        transform.DOMoveZ(60.5f,3f);
    }
}
