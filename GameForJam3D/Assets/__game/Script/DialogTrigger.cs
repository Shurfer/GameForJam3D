using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public int dialogNumber;
    public Dialog dialogSc;
    public bool insultape;
    public bool resetPos;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            dialogSc.DialogActivate(dialogNumber);
            if(insultape)
            {
                dialogSc.InsultapeUp();
                PlayerHealth playerSc = other.gameObject.GetComponent<PlayerHealth>();
                playerSc.insultapeCatch = true;
                playerSc.CardKeyGet(1);
                Destroy(transform.parent.gameObject);
            }
            if(resetPos)
            {
                PlayerHealth playerSc = other.gameObject.GetComponent<PlayerHealth>();
                playerSc.resetPosition = transform.position;
            }
            Destroy(gameObject);
        }
    }
}
