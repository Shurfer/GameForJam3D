using UnityEngine;

public class Artefact : MonoBehaviour, ITouchable
{
    private string text;
    private Color color;
    private void Start()
    {
        text = "Артефакт успешно забран!";
        color = Color.yellow;
    }
    public virtual void Touch()
    {
        ScriptСontainer.soundManager.PlayerHealthUp();
        ScriptСontainer.dialogManager.ActivateInfoText(text, color);
        ScriptСontainer.inventory.ArtefactCatch();
        Destroy(gameObject);
    }
}