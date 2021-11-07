
using UnityEngine;

public class Spear : MonoBehaviour
{
    public int damage;
    public float speed;
    private bool move;

    public void Activate()
    {
        move = true;
        Destroy(this,10);
    }
    void FixedUpdate()
    {
        if(move)
        transform.position += new Vector3(speed*Time.fixedDeltaTime, 0, 0);
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.GetDamage(damage);
        }
    }
}
