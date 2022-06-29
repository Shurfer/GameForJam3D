using UnityEngine;

public class TriggerResetPosition : MonoBehaviour // висит в районе воды
{
    [SerializeField] private Vector3 resetPos;

    private void OnTriggerEnter(Collider other)
    {
        ScriptСontainer.resetPosManager.NewResetPosition(resetPos);
        ScriptСontainer.resetPosManager.ResetPlayerPosition();
    }
}