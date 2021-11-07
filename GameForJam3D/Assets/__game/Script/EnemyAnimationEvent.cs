using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    public Enemy enemySc;
    
    public void Event()
    {
        enemySc.AnimationPunchOff();
    }
    
    public void Punch()
    {
        enemySc.PunchPlayer();
    }
}
