using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogCanvas;

    [SerializeField] Text speakerNameText;
    [SerializeField] Text dialogText;
    [SerializeField] Text infoText;

    [SerializeField] GameObject endGameGo;
    [SerializeField] GameObject buttonNext;
    [SerializeField]  GameObject answerButtons;
    
    bool dialogActive;

    private int phraseCount;

    private DialogList dialog;

    public void ActivateInfoText(string text, Color32 color) // текст для всех вещей
    {
        infoText.text = text;
        infoText.color = color;
        infoText.gameObject.SetActive(true);
        StartCoroutine(textForObjectFalse());
    }

    IEnumerator textForObjectFalse()
    {
        yield return new WaitForSeconds(3f);
        infoText.gameObject.SetActive(false);
    }

    void DialogCanvasActivate()
    {
        phraseCount = 0;
        dialogActive = true;
        dialogCanvas.SetActive(true);
    }

    public bool DialogActivate()
    {
        return dialogActive;
    }

    IEnumerator dialogOff()
    {
        yield return new WaitForSeconds(3f);
        DialogOff();
    }

    void DialogOff()
    {
        dialogActive = false;
        dialogCanvas.SetActive(false);
    }

    public void SetDialog(DialogList newDialog)
    {
        dialog = newDialog;
        DialogCanvasActivate();
        NextPhrase();
    }

    public void NextPhrase() // активация на enter через Dialog
    {
        if (phraseCount == dialog.DialogBody.Length)
            DialogOff();
        else
        {
            dialogText.text = dialog.DialogBody[phraseCount].dialogText;
            speakerNameText.text = dialog.DialogBody[phraseCount].speakerName;
            phraseCount++;
        }
    }

    public void EnemyDialogActivate(string text)
    {
        dialogText.text = text;
        DialogCanvasActivate();
        StartCoroutine(dialogOff());
    }
    
    public void PlayerLiveAfterBoss()
    {
        SetDialog(ScriptСontainer.dialogHolder.CharecterDialog[1].DialogList[1]);
    }

    public void PlayerDiedFromBoss()
    {
        buttonNext.SetActive(false);
        SetDialog(ScriptСontainer.dialogHolder.CharecterDialog[1].DialogList[2]);
        StartCoroutine(restartGame(5));
    }

    public void AnswerButtonsActivate()
    {
        buttonNext.SetActive(false);
        answerButtons.SetActive(true);
    }

    public void PlayerChooseAnswer(int num)
    {
        answerButtons.SetActive(false);
 
        if (num == 0) // нет
        {
            SetDialog(ScriptСontainer.dialogHolder.CharecterDialog[1].DialogList[4]);
            StartCoroutine(restartGame(5));
        }
 
        if (num == 1) // да
        {
            SetDialog(ScriptСontainer.dialogHolder.CharecterDialog[1].DialogList[3]);
            EndGame();
        }
    }
    public void EndGame()
    {
        endGameGo.SetActive(true);
        DialogOff();
        StartCoroutine(restartGame(10));
    }

    public void RestartGame() 
    {
        StopAllCoroutines();
        StartCoroutine(restartGame(1));
    }

    IEnumerator restartGame(int timeToReset)
    {
        yield return new WaitForSeconds(timeToReset);
        Time.timeScale = 1;
        SceneManager.LoadScene("game");
    }
}