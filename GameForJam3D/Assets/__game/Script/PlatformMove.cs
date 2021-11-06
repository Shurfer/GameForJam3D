using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speedSec;

    public Vector3 newPos;
    
    public bool stop;
    public Transform trans;
  /*  private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            trans = other.transform.parent.GetComponent<Transform>();
            trans.SetParent(transform);
        }
    }*/
    
    public Transform platformMove;
    public Transform endPos;
    private void Start()
    {
        if(!stop)
        platformMove.DOMove(endPos.position, speedSec).SetEase(Ease.Linear).OnComplete(MovePlatform);
    }

    void MovePlatform()
    {
        platformMove.position = transform.position;
        platformMove.DOMove(endPos.position, speedSec).SetEase(Ease.Linear).OnComplete(MovePlatform); 
    }
}
