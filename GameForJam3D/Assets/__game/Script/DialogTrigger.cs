using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public int dialogNumber;
    public Dialog dialogSc;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            dialogSc.DialogActivate(dialogNumber);
        }
    }
}
