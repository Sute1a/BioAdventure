using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Camera main, sub;

    public AudioSource audioSource;
    public AudioClip DoorMoveClip;

    private void Start()
    {
        main = main.GetComponent<Camera>();
        sub = sub.GetComponent<Camera>();
    }

    public void Open()
    {
        main.enabled = false;
        sub.enabled = true;

        transform.DOMoveZ(60.5f,3f).OnComplete(CamChange);
    }

    public void CamChange()
    {
        main.enabled = true;
        sub.enabled = false;
    }

    public void DoorMoveSE()
    {
        audioSource.clip = DoorMoveClip;
        audioSource.Play();
    }
}
