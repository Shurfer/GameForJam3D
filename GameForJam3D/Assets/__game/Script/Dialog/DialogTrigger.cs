using UnityEngine;

public class DialogTrigger : MonoBehaviour, ITouchable
{
    [SerializeField] int dialogNumber;

    [SerializeField] private Dialog Dialog;

    public void Touch()
    {
        Dialog.ActivateDialog(dialogNumber);
        Destroy(gameObject);
    }
}