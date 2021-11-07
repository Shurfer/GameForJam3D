using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardKey : MonoBehaviour
{
    private bool player;
    private PlayerHealth playerSc;
    public Dialog dialogSc;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            player = true;
            playerSc = other.gameObject.GetComponent<PlayerHealth>();
        }
    }

    private void Update()
    {
        if (player && Input.GetKeyDown(KeyCode.E))
        {
            dialogSc.CardKeyUp();
            playerSc.CardKeyGet(0);
            Destroy(gameObject);
        }
    }
}
