using UnityEngine;

public class Cake : MonoBehaviour, IUseable
{
    [SerializeField] SpearManager SpearManager;
    
    private string text;
    private Color color;

    private void Start()
    {
        text = "Потрясающе пронзающий торт!";
        color = Color.green;
    }
    public void Use()
    {
        ScriptСontainer.dialogManager.ActivateInfoText(text, color);
        SpearManager.ActivateSpear();
        Destroy(gameObject);
    }
}