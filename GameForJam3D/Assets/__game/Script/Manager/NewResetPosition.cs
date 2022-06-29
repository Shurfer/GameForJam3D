
using UnityEngine;

public class NewResetPosition : MonoBehaviour,ITouchable
{
    public void Touch()
    {
        ScriptСontainer.resetPosManager.NewResetPosition(transform.position);  
    }
}
