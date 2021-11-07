using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
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
        if (num == 0)
            dialogText.text =
                "-Ночью был ураган, половину моста снесло! Остальные куски держатся на честном слове, осторожней!";
        if (num == 1)
            dialogText.text =
                "-Эй, что ты здесь делаешь? это частная территория! Ану иди сюда, разберемся! Хотя стой, я сам подойду!";
        if (num == 2)
            dialogText.text =
                "-Удача, я забрался, где лежит артефакт? \n -Ищи большой красный ящик, надеюсь он на месте. \n -ЧТо?! \n -Нет,нет, все хорошо...";
        if (num == 3)
            dialogText.text =
                "-Здесь гребанная изолента!! \n - О чем это ты? \n - Вместо артефакта...лежит..синия изолента! \n -... \n -Поищи вокруг, артефакт где то должен быть";

        if (num == 7)
        {
            dialogText.text = "-Кто потревожил мой сон? Ану выходи на честный бой! Жду тебя за дверью!";
            StartCoroutine(artefactCatch());
        }

        if (num == 8)
        {
            dialogText.text =
                "-Эй Гарри, что за артефакт у нас заказали? \n - Обычная табличка для вызова демонов и прочее \n - Ясно, понятно..";
        }

        if (num == 10)
        {
            dialogText.text = "-Здесь нарушитель!!Раскулачим его!!";
            StartCoroutine(dialogOff());
        }
    }

    IEnumerator dialogOff()
    {
        yield return new WaitForSeconds(3f);
        dialogCanvas.SetActive(false);
        dialogActive = true;
    }

    public GameObject bossDialog;
    public Text bossDialogText;
    public void BossDialog(int num)
    {
        if (num == 0)
        {
            bossDialog.SetActive(true);
          //  dialogActive = true;
            dialogText.text = "-Итак, это ты меня разбудил..!?";
        }

        if (num == 1)
            bossDialogText.text = "-Что ты такое?!";
        if (num == 2)
        {
            bossDialogText.text =
                "-Нагромождение вокселей...Тоесть воксельное зло..Тоесть верховный воксель..Да что ты себе позволяешь, прозрачная капсула?";
          
        }
        if (num == 3)
        {
            bossAnimator.Play("punch");
            StartCoroutine(damageToPlayer());
            bossDialogText.text = "-Оуч, это было щекотно..";
        }
        if (num == 4)
        {
            bossDialogText.text = "-Ты более стойкий чем я думал, присоединяйся ко мне!!";
            buttonNext.SetActive(false);
            playerAnswers.SetActive(true);
        }
    }

    public GameObject playerAnswers;
    public GameObject buttonNext;
    private int dialogBossNum;
    public void PlayerBossNextDialog()
    {
        dialogBossNum++;
        BossDialog(dialogBossNum);
      //  Debug.Log(dialogBossNum);
    }
    

    public void PlayerChooseAnswer(int num)
    {
        playerAnswers.SetActive(false);
        if (num == 0) // да
        {
            bossDialogText.text = "-Отлично, у тебя есть голова на плечах! Начнем сразу же после сна..нужно досмотреть чем закончилось вторжение зайцев на капустное поле..";
            buttonEndGame.SetActive(true);
        }
        if (num == 1) // нет
        {
            bossDialogText.text = "-Какая наглость!! Возвращайся когда передумаешь!";
            timeToReset = 5;
            StartCoroutine(restartGame());
        }
    }

    public Animator bossAnimator;
    public GameObject buttonEndGame;
    public void EndGame()
    {
        endGameGo.SetActive(true);
        bossDialog.SetActive(false);
        timeToReset = 10;
        StartCoroutine(restartGame());
    }

    public void RestartGame()
    {
        timeToReset = 1;
        StartCoroutine(restartGame());
    }

    public GameObject endGameGo;
    IEnumerator damageToPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        playerHealth.boss=true;
        playerHealth.GetDamage(60);
        if(playerHealth.health<=0)
        {
            playerHealth.health = 0;
            buttonNext.SetActive(false);
            bossDialogText.text =
                "-Ты слишком слаб чтобы разговаривать со мной!!";
            timeToReset = 5;
            StartCoroutine(restartGame());
        }
        yield return new WaitForSeconds(1f);
        bossAnimator.Play("idle");
    }

    private int timeToReset;
    IEnumerator restartGame()
    {
        yield return new WaitForSeconds(timeToReset);
        Time.timeScale = 1;
        SceneManager.LoadScene("game");
    }

    public PlayerHealth playerHealth;
    public GameObject keyCardTextGo;

    public void KeyCardCatch()
    {
        keyCardTextGo.SetActive(true);
        StartCoroutine(keyCardCatchOff());
    }

    IEnumerator keyCardCatchOff()
    {
        yield return new WaitForSeconds(4f);
        keyCardTextGo.SetActive(false);
    }

    public GameObject keyNeedText;

    public void KeyNeed()
    {
        keyNeedText.SetActive(true);
        StartCoroutine(keyNeedOff());
    }

    IEnumerator keyNeedOff()
    {
        yield return new WaitForSeconds(4f);
        keyNeedText.SetActive(false);
    }

    IEnumerator artefactCatch()
    {
        yield return new WaitForSeconds(5f);
        DialogActivate(8);
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
        if (dialogActive && Input.GetKeyDown(KeyCode.Return))
            DialogOff();
    }
}