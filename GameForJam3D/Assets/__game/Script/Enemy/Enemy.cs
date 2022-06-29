using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    [SerializeField] protected BoxCollider boxColl;
    [SerializeField] protected CapsuleCollider capsColl;

    [HideInInspector] public bool nockOut;
    [HideInInspector] public bool moveToplayer;
    [HideInInspector] public bool playerCatch;
}