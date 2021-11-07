using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Dialog dialog;
   public GameObject player;
  public GameObject arm;
    public Transform playerHealth;

    public GameObject[] security;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
           playerHealth.SetParent(null);
           player.SetActive(false);
           arm.SetActive(false);
           Screen.lockCursor = false;
            Cursor.visible = true;
            dialog.BossDialog(0);
          //  Time.timeScale = 0;
          for (int i = 0; i < security.Length; i++)
          {
              security[i].SetActive(false);
          }
        }
    }
}
