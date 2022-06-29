
using UnityEngine;

public class HealthPack : MonoBehaviour, ITouchable
{
    public int healthPlus;

    public void Touch()
    {
        ScriptСontainer.player.GetHealthUp(healthPlus);
        Destroy(transform.parent.gameObject);
    }
}
