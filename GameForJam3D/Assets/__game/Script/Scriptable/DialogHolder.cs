using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable/DialogHolder", order = 1)]

public class DialogHolder : ScriptableObject
{
    public CharecterDialog[] CharecterDialog;
}

[System.Serializable]
public struct CharecterDialog
{
    public string characterName;
    public DialogList[] DialogList;
}

[System.Serializable]
public struct DialogList
{
    public string placeName;
    public DialogBody[] DialogBody;
}

[System.Serializable]
public struct DialogBody
{
    public string speakerName;
    public string dialogText;
}