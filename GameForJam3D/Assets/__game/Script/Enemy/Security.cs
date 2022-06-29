using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Security : Enemy, IDamageable
{
    [SerializeField] bool inRoom;
    [SerializeField]  GameObject cardKey;
    
    Transform playerTr;
    NavMeshAgent agent;

    IDamageable _damageable;

    EnemyMoving enemyMoving;
    EnemyAnimatorManager animator;

    string[] dialoText;

    private void Start()
    {
        EventManager.PlayerDied.AddListener(Reset);
        enemyMoving = GetComponent<EnemyMoving>();
        animator = GetComponentInChildren<EnemyAnimatorManager>();
        dialoText = new string[2];
        dialoText[0] = "-Эй, что ты здесь делаешь? Это частная территория!";
        dialoText[1] = "-Здесь нарушитель!! Раскулачим его!!";
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        animator.PlayAnimation("hit");
        ScriptСontainer.soundManager.EnemyHit();
        if (health <= 0)
            Death();
    }

    void Death()
    {
        moveToplayer = false;
        capsColl.enabled = false;
        boxColl.enabled = false;
        enemyMoving.StopMoving();
        animator.PlayAnimation("fall");
        if (cardKey != null)
            cardKey.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCatch  && moveToplayer && other.CompareTag("PlayerHealth")) // capsule
        {
            PunchTarget();
        }

        if (!playerCatch && !moveToplayer && other.CompareTag("PlayerHealth")) // box 
        {
            _damageable = other.gameObject.GetComponent<IDamageable>();
            playerTr = other.transform;
            ReadyMoveToTarget();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!moveToplayer && other.CompareTag("PlayerHealth"))
        {
            StartCoroutine(runAgain());
        }
    }
    
    void PunchTarget()
    {
        moveToplayer = false;
        transform.LookAt(playerTr);
        animator.PlayAnimation("punch");

        enemyMoving.StopMoving();
    }

    void ReadyMoveToTarget()
    {
        playerCatch = true;
        moveToplayer = true;

        boxColl.enabled = false;
        capsColl.enabled = true;

        enemyMoving.MovingToTarget(playerTr);

        ScriptСontainer.dialogManager.EnemyDialogActivate(dialoText[0]);
        if (inRoom)
            ScriptСontainer.dialogManager.EnemyDialogActivate(dialoText[1]);
    }
    

    IEnumerator runAgain()
    {
        yield return new WaitForSeconds(0.5f);
        moveToplayer = true;
        enemyMoving.MovingToTarget(playerTr);
    }

    public void AnimationHitOff()
    {
        moveToplayer = true;
        PunchTarget();
    }

    public void PunchPlayer()
    {
        if (playerTr != null)
        {
            float dist = Vector3.Distance(playerTr.position, transform.position);
            if (dist < 3)
                _damageable.GetDamage(damage);
        }
    }

    void Reset() 
    {
        _damageable = null;
        playerTr = null;

        moveToplayer = false;
        playerCatch = false;
        boxColl.enabled = true;
        capsColl.enabled = false;

        if (inRoom)
            enemyMoving.ChangePointPos();
    }
}