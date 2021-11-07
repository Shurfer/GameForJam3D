using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public Spear[] spear;
    private int spearCount;
    private bool activate;
    public BoxCollider boxCol;
    public GameObject cakeGo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            activate = true;
        }
    }

    IEnumerator desActivate()
    {
        yield return new WaitForSeconds(0.2f);
        spear[spearCount].Activate();
        spearCount++;
        if (spearCount < spear.Length)
            StartCoroutine(desActivate());
    }

    private void Update()
    {
        if (activate && Input.GetKeyDown(KeyCode.E))
        {
            activate = false;
            boxCol.enabled = false;
            Destroy(cakeGo);
            StartCoroutine(desActivate());
        }
    }
}