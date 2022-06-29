using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] Transform centrTr; // центр левела - для создания рандомной точки на меше
    Vector3 endPoint; // конечная точка движения

    Transform targetTr;
    NavMeshAgent agent;
    [HideInInspector] public bool checkEndPos;
    public bool inRoom;

    private EnemyAnimatorManager animator;

    private bool movingToTarget;

    private void Start()
    {
        animator = GetComponentInChildren<EnemyAnimatorManager>();
        agent = GetComponent<NavMeshAgent>();
        if (inRoom)
            ChangePointPos();
    }

    public void MovingToTarget(Transform target)
    {
        targetTr = target;

        movingToTarget = true;
        agent.isStopped = false;
        checkEndPos = false;
        animator.PlayAnimation("run");
    }

    public void StopMoving()
    {
        movingToTarget = false;
        agent.isStopped = true;
    }

    public void ChangePointPos() // смена позии конечной точки   // Debug.DrawRay(point, Vector3.up, Color.red, 1.0f);
    {
        if (RandomPoint(centrTr.position, out Vector3 point))
        {
            endPoint = point;
            MoveToRandomPoint(); // продолжить движение
        }
        else
            ChangePointPos();
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

    public void MoveToRandomPoint() // движение к точке на карте - бегом
    {
        if (agent.isStopped)
            agent.isStopped = false;
        animator.PlayAnimation("run");
        agent.SetDestination(endPoint);
        checkEndPos = true; // update проверка на касание точки
    }

    void Update()
    {
        if (movingToTarget)
        {
            transform.LookAt(targetTr);
            agent.SetDestination(targetTr.position - new Vector3(0, 0, -2));
        }

        if (inRoom && checkEndPos && transform.position.x == endPoint.x)
        {
            checkEndPos = false;
            ChangePointPos();
        }
    }
}