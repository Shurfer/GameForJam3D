using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour, ITouchable
{
    [SerializeField] private Animator Animator;

    public void Touch()
    {
        ScriptСontainer.player.PlayerStanFromBoss();
    }

    public void PunchPlayer()
    {
        Animator.Play("punch");
        StartCoroutine(damageToPlayer());
    }

    IEnumerator damageToPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        CheckPlayerHealth(ScriptСontainer.player.HealthFromBossAttack(60));

        yield return new WaitForSeconds(1f);
        Animator.Play("idle");
    }

    void CheckPlayerHealth(int health)
    {
        if (health <= 0)
            ScriptСontainer.dialogManager.PlayerDiedFromBoss();
        else if (health > 0)
        {
            ScriptСontainer.dialogManager.AnswerButtonsActivate();
            ScriptСontainer.dialogManager.PlayerLiveAfterBoss();
        }
    }
}