using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healthPlus;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            PlayerHealth  playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.GetHealthUp(healthPlus);
            Destroy(gameObject);
        }
    }
    

}
