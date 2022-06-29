using UnityEngine;

public class ScriptContainerManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] InputManager inputManager;
    [SerializeField] Inventory inventory;

    [SerializeField] Boss boss;

    [SerializeField] DialogManager dialogManager;
    [SerializeField] DialogHolder dialogHolder;

    [SerializeField] SoundManager soundManager;
    [SerializeField] ResetPositionManager resetPosManager;

    private void Awake()
    {
        ScriptСontainer.player = player;
        ScriptСontainer.inventory = inventory;
        ScriptСontainer.inputManager = inputManager;

        ScriptСontainer.boss = boss;

        ScriptСontainer.dialogHolder = dialogHolder;
        ScriptСontainer.dialogManager = dialogManager;

        ScriptСontainer.soundManager = soundManager;
        ScriptСontainer.resetPosManager = resetPosManager;
    }
}