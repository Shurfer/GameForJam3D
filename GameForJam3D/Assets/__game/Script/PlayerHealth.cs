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
    }
    public void GetDamage(int damage)
    {
        soundManager.PlayerGetDamage();
        health -= damage;
        healthText.text = health.ToString();
        damageImage.SetActive(true);
        StartCoroutine(damageOff());
        if(health<=0)
            SceneManager.LoadScene("1");
    }

    public void GetHealthUp(int healthUp)
    {
        soundManager.PlayerHealthUp();
        health += healthUp;
        healthText.text = health.ToString();
        healthUpImage.SetActive(true);
        StartCoroutine(healthUpOff());
    }
    
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
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (objMayCatch)
            {
                soundManager.ObjectPickUp();
                objMayCatch = false;
                objCatchTr.SetParent(playerTr);
                if (objCatchTr.localPosition.y < 0)
                    objCatchTr.localPosition = new Vector3(0.5f,0.5f,1);
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
        if (objCatchTr==null)
            objCatch = false;
    }
}
