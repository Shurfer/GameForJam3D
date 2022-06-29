
using UnityEngine;

public class Door : MonoBehaviour, IUseable
{
    private string text;
    private Color color;
    private void Start()
    {
        text = "Нужен ключ";
        color = Color.red;
    }
    public void Use()
    {
        if (ScriptСontainer.inventory.MayDoorOpen())
        {
            ScriptСontainer.soundManager.DoorOpen();
            Destroy(transform.parent.gameObject);
        }
        else
            ScriptСontainer.dialogManager.ActivateInfoText(text, color);
    }
}
