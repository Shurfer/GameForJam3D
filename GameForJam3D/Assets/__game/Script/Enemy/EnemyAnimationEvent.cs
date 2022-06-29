using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    public Security enemy;

    public void HitAnimationOff()
    {
       enemy.AnimationHitOff();
    }

    public void Punch()
    {
        enemy.PunchPlayer();
    }
}