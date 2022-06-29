public class DialogWithBoss : Dialog
{
    private int bossNum;

    public override void NextPhrase()
    {
        base.NextPhrase();
        bossNum++;
        if (bossNum == 4)
            ScriptСontainer.boss.PunchPlayer();
    }

    public override void ActivateDialog(int num)
    {
        ScriptСontainer.dialogManager.SetDialog(ScriptСontainer.dialogHolder.CharecterDialog[1].DialogList[num]);
    }
    
}