using UnityEngine;

public class ResetPositionManager : MonoBehaviour
{
    [SerializeField] Transform playerTr;

    Vector3 resetPosition;

    private void Start()
    {
        EventManager.PlayerDied.AddListener(ResetPlayerPosition);
    }

    public void NewResetPosition(Vector3 resetPosition)
    {
        this.resetPosition = resetPosition;
    }

    public void ResetPlayerPosition()
    {
        ScriptСontainer.soundManager.ResetPosition();
        playerTr.gameObject.SetActive(false);
        playerTr.position = resetPosition;
        playerTr.gameObject.SetActive(true);
    }
}