using System;
using UnityEngine;

public class CardKey : MonoBehaviour, ITouchable
{
    private string text;
    private Color color;
    private void Start()
    {
        text = "Половина ключ-карты поднята";
        color = Color.red;
    }

    public void Touch()
    {
        ScriptСontainer.dialogManager.ActivateInfoText(text, color);
        ScriptСontainer.inventory.CardKeyGet();
        Destroy(gameObject);
    }
}
