public class DialogWithPartner : Dialog
{
    public override  void ActivateDialog(int num)
    {
        ScriptСontainer.dialogManager.SetDialog(ScriptСontainer.dialogHolder.CharecterDialog[0].DialogList[num]);
        ScriptСontainer.inputManager.SetDialogable(this);
    }
}
