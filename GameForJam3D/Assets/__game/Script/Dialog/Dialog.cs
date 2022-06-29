using UnityEngine;

public  class Dialog : MonoBehaviour
{
    public virtual void NextPhrase()
    {
        ScriptСontainer.dialogManager.NextPhrase();
    }

    public virtual void ActivateDialog(int num)
    {
    }
}