using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRestPosition : MonoBehaviour
{

    public Vector3 resetPos;

    public Transform playerTr;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            PlayerHealth playerSc = other.gameObject.GetComponent<PlayerHealth>();
            playerSc.ResetPosition(); //звук
            Transform  playerTr = other.transform.parent.GetComponentInParent<Transform>();
             playerTr.gameObject.SetActive(false);
            playerTr.position = resetPos;
            playerTr.gameObject.SetActive(true);
        }
    }

    public void ResetPlayerPosition(Vector3 newPos)
    {
        playerTr.gameObject.SetActive(false);
        playerTr.position = newPos;
        playerTr.gameObject.SetActive(true);
    }
}
