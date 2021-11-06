using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
   // public float speedSec;

   // public Vector3 newPos;
    
    public bool stop;
 //   public Transform trans;
    public Rigidbody rig;
   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
           // trans = other.transform.parent.GetComponent<Transform>();
           // trans.SetParent(transform);
           if(!stop)
           {
              // rig.useGravity = true;
              MovePlatform();
               Destroy(gameObject, 5);
           }
        }
    }
   
   void MovePlatform()
   {
       transform.DOMove(transform.position-new Vector3(0,10,0), 2).SetEase(Ease.Linear);
   }
    
  /*  public Transform platformMove;
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
    }*/
}
