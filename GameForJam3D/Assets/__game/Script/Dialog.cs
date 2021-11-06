using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Dialog : MonoBehaviour
{
    public GameObject dialogCanvas;

    public GameObject playerGo;

    private void Start()
    {
      //  StartCoroutine(coursor());
    }

    IEnumerator coursor()
    {
        yield return new WaitForSeconds(1f);
        dialogCanvas.SetActive(true);
        playerGo.SetActive(false);
       // Cursor.visible = true;
    }

    public void BackToGame()
    {
        ok = true;
        dialogCanvas.SetActive(false);
        playerGo.SetActive(true);
      //  Cursor.visible = true;
    }

    private bool ok;
    private void Update()
    {
        if(!ok && Input.GetKeyDown(KeyCode.Return))
        BackToGame();
    }
}