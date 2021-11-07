using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Artefact : MonoBehaviour
{
    private bool player;
     Dialog dialogSc;

    private void Start()
    {
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
            Destroy(gameObject);
        }
    }
}
