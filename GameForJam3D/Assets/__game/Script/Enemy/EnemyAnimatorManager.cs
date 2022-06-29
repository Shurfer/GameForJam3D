using UnityEngine;

public class EnemyAnimatorManager : MonoBehaviour
{
    
    [HideInInspector] public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }
}
