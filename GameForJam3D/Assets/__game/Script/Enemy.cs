using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private bool move;
    public int damage;
    private Transform playerTr;
    public Animator animator;
    public BoxCollider boxColl;
    public CapsuleCollider capsColl;
    private PlayerHealth playerHealth;
    private bool setDamage;
   // public Rigidbody rig;
   public NavMeshAgent agent;
    private void OnTriggerEnter(Collider other)
    {
        if (move && other.tag == "PlayerHealth")
        {
            animator.Play("punch");
        }
        
        if (other.tag == "PlayerHealth")
        {
            animator.enabled = true;
            playerTr = other.transform;
            move = true;
            boxColl.enabled = false;
            capsColl.enabled = true;
           
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (move&& other.tag == "PlayerHealth")
        {
            animator.Play("run");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerHealth" && !setDamage)
        {
            setDamage = true;
  
            StartCoroutine(damageOff());
        }
    }

    IEnumerator damageOff()
    {
        yield return new WaitForSeconds(1f);
        playerHealth.GetDamage(damage);
        setDamage = false;
    }

    private Vector3 posMove;
    void Update()
    {
      if (move)
        {
            /*  posMove = new Vector3(playerTr.position.x-0.5f, transform.position.y, playerTr.position.z-0.5f);
             rig.DOMove( posMove, 2); //.From();
             */
               agent.SetDestination(playerTr.position-new Vector3(0,0,-2));
        }
    }
}