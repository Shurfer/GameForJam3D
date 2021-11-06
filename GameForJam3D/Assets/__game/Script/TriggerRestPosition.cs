using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRestPosition : MonoBehaviour
{

    public Vector3 resetPos;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            PlayerHealth playerSc = other.gameObject.GetComponent<PlayerHealth>();
            playerSc.ResetPosition();
            Transform  playerTr = other.transform.parent.GetComponentInParent<Transform>();
             playerTr.gameObject.SetActive(false);
            playerTr.position = resetPos;
            playerTr.gameObject.SetActive(true);
        }
    }
}
