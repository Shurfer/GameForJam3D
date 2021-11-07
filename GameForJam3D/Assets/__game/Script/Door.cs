using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public SoundManager soundManager;
    public Dialog dialog;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {

            PlayerHealth  playerSc = other.gameObject.GetComponent<PlayerHealth>();
            if (playerSc.doorMayOpen)
            {
                soundManager.DoorOpen();
                Destroy(transform.parent.gameObject);
            }
            else
                dialog.KeyNeed();
        }
    }
}
