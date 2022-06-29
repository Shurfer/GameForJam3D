using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent PlayerDied = new UnityEvent();

    public static void SendPlayerPositionReset()
    {
        PlayerDied.Invoke();
    }

}