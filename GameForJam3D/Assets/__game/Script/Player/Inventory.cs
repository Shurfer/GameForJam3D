using UnityEngine;

public class Inventory : MonoBehaviour
{
    private PlayerUI PlayerUI;

    private int artefactCount;
    private int cardNum;

    bool doorMayOpen;
    bool insultapeCatch;

    private string text;
    private Color color;

    private void Start()
    {
        PlayerUI = GetComponent<PlayerUI>();
        text = "Ключ собран";
        color = Color.green;
    }

    public void ArtefactCatch()
    {
        artefactCount++;
        PlayerUI.ChangeArtefactText(artefactCount);
    }

    public void InsultapeCatch(bool value)
    {
        insultapeCatch = value;
        CureKeyCard();
    }

    public void CardKeyGet()
    {
        cardNum++;
        CureKeyCard();
    }

    void CureKeyCard() 
    {
        if (cardNum == 2 && insultapeCatch)
        {
            doorMayOpen = true;
            ScriptСontainer.dialogManager.ActivateInfoText(text, color);
        }
    }

    public bool MayDoorOpen()
    {
        return doorMayOpen;
    }
}