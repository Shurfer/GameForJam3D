using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject dialogCanvas;

    public GameObject playerGo;
    public Text dialogText;
    private bool dialogActive;

    private void Start()
    {
        DialogActivate(0);

    }

    public void DialogActivate(int num)
    {
        DialogText(num);
        dialogCanvas.SetActive(true);
        dialogActive = true;
    }

    void DialogText(int num)
    {
        if(num == 0)
            dialogText.text = "-Ночью был ураган, половину моста снесло! Остальные куски держатся на честном слове, осторожней!";
        if(num == 1)
            dialogText.text = "-Эй, что ты здесь делаешь? это частная территория! Ану иди сюда, разберемся! Хотя стой, я сам подойду!";
        if(num == 2)
            dialogText.text = "-Удача, я забрался, где лежит артефакт? \n -Ищи большой красный ящик, надеюсь он на месте. \n -ЧТо?! \n -Нет,нет, все хорошо...";
        if(num == 3)
            dialogText.text = "-Здесь гребанная изолента!! \n - О чем это ты? \n - Вместо артефакта...лежит..синия изолента! \n -... \n -Поищи вокруг, артефакт где то должен быть";
    }
    

    public void DialogOff()
    {
        dialogActive = false;
        dialogCanvas.SetActive(false);
    }

    public GameObject artefactText;
    public Text artefactCountText;
    private int artefactCount;
    
    public void ArtefactCatch()
    {
        artefactCount++;
        artefactCountText.text = artefactCount.ToString();
        artefactText.SetActive(true);
        StartCoroutine(artefactTextOff());
    }
    
    IEnumerator artefactTextOff()
    {
        yield return new WaitForSeconds(3f);
        artefactText.SetActive(false);
    }

    public void CardKeyUp()
    {
        cardKeyTextGo.SetActive(true);
        StartCoroutine(CardKeyOFF());
    }
    
    IEnumerator CardKeyOFF()
    {
        yield return new WaitForSeconds(3f);
        cardKeyTextGo.SetActive(false);
    }

    public GameObject cardKeyTextGo;
    
    public void InsultapeUp()
    {
        insultapeTextGo.SetActive(true);
        StartCoroutine(insultapeOFF());
    }
    
    IEnumerator insultapeOFF()
    {
        yield return new WaitForSeconds(3f);
        insultapeTextGo.SetActive(false);
    }

    public GameObject insultapeTextGo;
    private void Update()
    {
        if(dialogActive && Input.GetKeyDown(KeyCode.Return))
            DialogOff();
    }
}