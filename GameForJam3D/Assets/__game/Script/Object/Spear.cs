using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField] BoxCollider boxColl;

    int damage = 4;
    float speed = 20;

    bool move;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable _damagable))
        {
            _damagable.GetDamage(damage);
            boxColl.enabled = false;
        }
    }

    public void Activate(int side)
    {
        move = true;
        Destroy(this, 3);
        speed = speed * side;
    }

    void Update()
    {
        if (move)
            transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
    }
}