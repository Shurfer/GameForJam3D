using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public Text healthText;
    public GameObject damageImage;
    public GameObject healthUpImage;

    public SoundManager soundManager;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Catch" || other.tag == "Artefact" || other.tag == "Trap" || other.tag == "Card")
        {
            pressEGo.SetActive(true);
        }

        if (!objCatch && other.tag == "Catch")
        {
            objMayCatch = true;
            objCatchTr = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Catch")
        {
            objMayCatch = false;
        }

        if (other.tag == "Catch" || other.tag == "Artefact" || other.tag == "Trap")
        {
            pressEGo.SetActive(false);
        }
    }

    public void GetDamage(int damage)
    {
        soundManager.PlayerGetDamage();
        health -= damage;
        healthText.text = health.ToString();
        damageImage.SetActive(true);
        StartCoroutine(damageOff());
        if (health <= 0)
            triggerPos.ResetPlayerPosition(resetPosition);
          //  SceneManager.LoadScene("1");
    }

    public Vector3 resetPosition;
    public TriggerRestPosition triggerPos;
    public void GetHealthUp(int healthUp)
    {
        soundManager.PlayerHealthUp();
        health += healthUp;
        healthText.text = health.ToString();
        healthUpImage.SetActive(true);
        StartCoroutine(healthUpOff());
    }

    private int cardNum;
    public bool insultapeCatch;

    public void CardKeyGet(int num)
    {
        if (num == 0)
            cardNum++;
        if (cardNum == 2 && insultapeCatch)
            doorMayOpen = true;
    }

    public bool doorMayOpen;

    IEnumerator damageOff()
    {
        yield return new WaitForSeconds(0.1f);
        damageImage.SetActive(false);
    }

    IEnumerator healthUpOff()
    {
        yield return new WaitForSeconds(0.1f);
        healthUpImage.SetActive(false);
    }

    public Transform playerTr;
    bool objCatch;
    private Transform objCatchTr;
    private bool objMayCatch;

    public GameObject pressEGo;

    IEnumerator objCatchTrue()
    {
        yield return new WaitForSeconds(1f);
        objCatch = true;
    }

    public void Jump()
    {
        soundManager.PLayerJump();
    }

    public void ResetPosition()
    {
        soundManager.ResetPosition();
    }

    IEnumerator armBack()
    {
        yield return new WaitForSeconds(0.2f);
        armTr.localPosition -= new Vector3(0, 0, 0.5f);
        armColl.enabled = false;
        atackArm = false;
    }

    public BoxCollider armColl;
    public Transform armTr;
    private bool atackArm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0))
        {
            if (!atackArm)
            {
                atackArm = true;
                StartCoroutine(armBack());
                armColl.enabled = true;
                armTr.localPosition += new Vector3(0, 0, 0.5f);
            }

            if (pressEGo.activeSelf)
                pressEGo.SetActive(false);
            if (objMayCatch)
            {
                soundManager.ObjectPickUp();
                objMayCatch = false;
                objCatchTr.SetParent(playerTr);
                if (objCatchTr.localPosition.y < 0)
                    objCatchTr.localPosition = new Vector3(0.25f, 0.33f, 1.5f);
                objCatchTr.gameObject.GetComponent<Rigidbody>().useGravity = false;
                StartCoroutine(objCatchTrue());
            }

            if (objCatch)
            {
                soundManager.ObjectPickOff();
                objCatchTr.parent = null;
                objCatchTr.gameObject.GetComponent<Rigidbody>().useGravity = true;
                objCatch = false;
            }
        }
        
        if (objCatchTr == null)
            objCatch = false;
    }
}