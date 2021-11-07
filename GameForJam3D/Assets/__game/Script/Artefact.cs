using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Artefact : MonoBehaviour
{
    private bool player;
     Dialog dialogSc;

     public bool tablet;
     
     private SoundManager soundManager;
     private void Start()
     {
         soundManager = FindObjectOfType<SoundManager>();
         dialogSc = FindObjectOfType<Dialog>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            player = true;
        }
    }

    private void Update()
    {
        if (player && Input.GetKeyDown(KeyCode.E))
        {
            dialogSc.ArtefactCatch();
            soundManager.PlayerHealthUp();
            if(tablet)
                dialogSc.DialogActivate(7);
            Destroy(gameObject);
        }
    }
}
