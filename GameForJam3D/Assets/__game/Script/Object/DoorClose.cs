using UnityEngine;

public class DoorClose : MonoBehaviour, IUseable
{
    private string text;
    private Color color;
    private void Start()
    {
        text = "Дверь заперта";
        color = Color.red;
    }

    public void Use()
    {
        ScriptСontainer.dialogManager.ActivateInfoText(text, color);
    }
}
