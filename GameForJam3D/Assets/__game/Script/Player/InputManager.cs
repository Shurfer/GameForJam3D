using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Hand Hand;

    private PlayerUI PlayerUI;

    private Dialog dialog;

    private bool isUseable;

    private void Start()
    {
        PlayerUI = GetComponent<PlayerUI>();
    }

    private IUseable _useble;

    public void UseableObject(IUseable useble)
    {
        isUseable = true;
        _useble = useble;
    }

    public void UseableObjectDisable()
    {
        isUseable = false;
        _useble = null;
        PlayerUI.CanInteractWithObject(false);
    }

    void InteractButtonDown()
    {
        if (isUseable && _useble != null)
        {
            _useble.Use();
            UseableObjectDisable();
        }
        else
            Hand.CheckHandForActive();

        PlayerUI.CanInteractWithObject(false);
    }

    public void SetDialogable(Dialog dialog)
    {
        this.dialog = dialog;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0))
            InteractButtonDown();

        if (Input.GetKeyDown(KeyCode.Return) && dialog != null && ScriptСontainer.dialogManager.DialogActivate())
            dialog.NextPhrase();
    }
}