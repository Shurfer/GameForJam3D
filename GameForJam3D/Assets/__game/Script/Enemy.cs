using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

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

    public int health;

    // public Rigidbody rig;
    public NavMeshAgent agent;

    public Dialog dialogSc;
    public Vector3 endPoint; // конечная точка движения
    public Transform centrTr; // центр левела - для создания рандомной точки на меше
    public bool inRoom;

    private void Start()
    {
        if (inRoom)
            ChangePointPos();
    }

    void ChangePointPos() // смена позии конечной точки   // Debug.DrawRay(point, Vector3.up, Color.red, 1.0f);
    {
        if (RandomPoint(centrTr.position, out Vector3 point))
        {
            endPoint = point;
            Move(); // продолжить движение
        }
        else
        {
            ChangePointPos();
        }
    }

    bool RandomPoint(Vector3 center, out Vector3 result) // создание рандомной точки
    {
        Vector3 randomPoint =
            center + new Vector3(Random.Range(-35, 35), 0,
                Random.Range(-35, 35)); //center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    
    public void Move() // движение к точке на карте - бегом
    {
        animator.Play("run");
        agent.SetDestination(endPoint); // движение к точке
        checkEndPos = true; // update проверка на касание точки
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!nockOut && move && other.tag == "PlayerHealth")
        {
            move = false;
            transform.LookAt(playerTr);
            animator.Play("punch");
        }

        if (!nockOut && !move && other.tag == "PlayerHealth")
        {
            animator.enabled = true;
            playerTr = other.transform;
            move = true;
            animator.Play("run");
            boxColl.enabled = false;
            capsColl.enabled = true;
            dialogSc.DialogActivate(1);
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        }

        if (other.tag == "AttackArm")
        {
            health--;
            animator.Play("hit");
            hit = true;
            if (health <= 0)
            {
                nockOut = true;
                move = false;
                capsColl.enabled = false;
                animator.Play("fall");
            }
        }
    }

    private bool hit;

    public void AnimationPunchOff()
    {
        hit = false;
        animator.Play("punch");
    }

    public void PunchPlayer()
    {
        playerHealth.GetDamage(damage);
    }

    private bool nockOut;

    private void OnTriggerExit(Collider other)
    {
        if (!nockOut && move && other.tag == "PlayerHealth")
        {
            move = false;
            StartCoroutine(runAgain());
        }
    }

    IEnumerator runAgain()
    {
        yield return new WaitForSeconds(0.5f);
        animator.Play("run");
        move = true;
    }

    private Vector3 posMove;
     bool checkEndPos;
    void Update()
    {
        if (!nockOut && playerTr != null)
            transform.LookAt(playerTr);
        if (move)
        {
            /*  posMove = new Vector3(playerTr.position.x-0.5f, transform.position.y, playerTr.position.z-0.5f);
             rig.DOMove( posMove, 2); //.From();
             */
            agent.SetDestination(playerTr.position - new Vector3(0, 0, -2));
        }
        
        if (inRoom&&checkEndPos && transform.position.x == endPoint.x)
        {
            checkEndPos = false;
            ChangePointPos();
        }
    }
}