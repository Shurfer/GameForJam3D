using UnityEngine;

public class Insultape : MonoBehaviour, ITouchable
{
    private string text;
    private Color color;

    private void Start()
    {
        text = "Изолента поднята";
        color = Color.blue;
    }

    public void Touch()
    {
        ScriptСontainer.dialogManager.ActivateInfoText(text, color);
        ScriptСontainer.inventory.InsultapeCatch(true);
        Destroy(transform.parent.gameObject);
    }
}