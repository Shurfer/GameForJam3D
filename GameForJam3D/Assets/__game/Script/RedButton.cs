using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public Spear[] spear;
    public GameObject[] flour;
    public Animator doorAnimator;

    public GameObject text;

    public MeshRenderer meshRenderer;
    public Material blue;
public Material red;

public CapsuleCollider collider;
    // при нажатии кнопки - появляются копья
    // пропадает пол
    // открывается дверь

    private int spearCount;
    private bool activate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            text.SetActive(true);
            activate = true;
        }
    }

    void Activate(int num)
    {
        if (num == 0)
            StartCoroutine(desActivate());
        if (num == 1)
            FlourOff();
        if (num == 2)
            doorAnimator.enabled = true;
    }

    IEnumerator desActivate()
    {
        yield return new WaitForSeconds(0.2f);
        spear[spearCount].Activate();
        spearCount++;
        if (spearCount < spear.Length)
            StartCoroutine(desActivate());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerHealth")
        {
            activate = false;
            text.SetActive(false);
        }
    }

    private int flourNumber;
    void FlourOff()
    {
        flour[flourNumber].SetActive(false);
        flourNumber++;
        if(flourNumber<flour.Length)
        StartCoroutine(flourOffTimer());
    }
    
    IEnumerator flourOffTimer()
    {
        yield return new WaitForSeconds(3);
        FlourOff();
        StartCoroutine(flourOffTimer());
    }

   public int activateNumber;
    private void Update()
    {
        if (activate && Input.GetKeyDown(KeyCode.E))
        {
            Activate(activateNumber);
            activateNumber++;
            activate = false;
            text.SetActive(false);
            meshRenderer.sharedMaterial = blue;
            collider.enabled = false;
            transform.position -= new Vector3(0, 0.05f, 0);
            StartCoroutine(activateAgain());
        }
    }
    
    IEnumerator activateAgain()
    {
        yield return new WaitForSeconds(2);
        meshRenderer.sharedMaterial = red;
        transform.position += new Vector3(0, 0.05f, 0);
        collider.enabled = true;
    }
}