using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {

            PlayerHealth  playerSc = other.gameObject.GetComponent<PlayerHealth>();
            if(playerSc.doorMayOpen)
                Destroy(transform.parent.gameObject);
        }
    }
}
